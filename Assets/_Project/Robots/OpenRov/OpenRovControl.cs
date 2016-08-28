using UnityEngine;
using System.Collections;

public class OpenRovControl : MonoBehaviour {
	public Thruster _verticalThruster;
	public Thruster _portThruster;
	public Thruster _starboardThruster;

	// TODO make thrust power private?
	public float _thrustPower;

	// TODO remove this reference and switch to location based thrust
	public Rigidbody _rovRigidBody;
	// Use this for initialization
	void Start () {
		_rovRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float horizontal = Input.GetAxis(Axes.HORIZONTAL);
		applyTorque(horizontal * Vector3.up);

		float forward = Input.GetAxis(Axes.FORWARD);
		Vector3 forwardThrustVector = _thrustPower * forward * Vector3.forward;
		applyForce(forwardThrustVector);
		
		float depth = Input.GetAxis(Axes.DEPTH);
		Vector3 depthThrustVector = _thrustPower * depth * Vector3.up * 2;
		applyForce(depthThrustVector);
		
	}

	private void applyTorque(Vector3 torque) {
		_rovRigidBody.AddRelativeTorque(torque);
		
	}
	private void applyForce(Vector3 force) {
		Vector3 globalPosition = _rovRigidBody.transform.TransformPoint(_rovRigidBody.centerOfMass);
		Vector3 globalDirection = _rovRigidBody.transform.TransformDirection(force);
		Debug.DrawRay(globalPosition, globalDirection, Color.red);
		_rovRigidBody.AddRelativeForce(globalDirection);
	}

	// we can't use this yet because the OpenRov model does not have a good center of mass
	private void locationSensitiveUpdate() {
		float horizontal = Input.GetAxis(Axes.HORIZONTAL);
		// note that the rear thrusters are mounted facing backwards
		// so their power needs to be reversed (that's why starboard
		// gets the -1 multiplier instead of port)
		_starboardThruster.powerThruster(_thrustPower * horizontal);
		_portThruster.powerThruster(-1 * _thrustPower * horizontal);

		float forward = Input.GetAxis(Axes.FORWARD);
		_starboardThruster.powerThruster(-1 * _thrustPower * forward);
		_portThruster.powerThruster(-1 * _thrustPower * forward);
		
		float depth = Input.GetAxis(Axes.DEPTH);
		_verticalThruster.powerThruster(_thrustPower * depth);
	}
}
