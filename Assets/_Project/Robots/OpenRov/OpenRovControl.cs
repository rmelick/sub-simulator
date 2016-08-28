using UnityEngine;
using System.Collections;

public class OpenRovControl : MonoBehaviour {
	public GameObject _verticalThrusterMarker;
	public GameObject _starboardThrusterMarker;
	public GameObject _portThrusterMarker;

	private Rigidbody _rovRigidBody;
	// TODO make thrust private?
	public float _thrustPower;
	// Use this for initialization
	void Start () {
		_rovRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis(Axes.HORIZONTAL);
		// note that the rear thrusters are mounted facing backwards
		// so their power needs to be reversed (that's why starboard
		// gets the -1 multiplier instead of port)
		powerThruster(_starboardThrusterMarker, -1 * horizontal);
		powerThruster(_portThrusterMarker, horizontal);

		float forward = Input.GetAxis(Axes.FORWARD);
		powerThruster(_starboardThrusterMarker, forward);
		powerThruster(_portThrusterMarker, forward);
		
		float depth = Input.GetAxis(Axes.DEPTH);
		powerThruster(_verticalThrusterMarker, depth);
	}

	private void powerThruster(GameObject thrusterMarker, float power) {
		if (power == 0) {
			return;
		}
		Vector3 thrustPosition = thrusterMarker.transform.position;
		Vector3 thrustDirection = Vector3.forward;
		Vector3 thrustForce = thrustDirection * _thrustPower * power;
		//_rovRigidBody.AddForceAtPosition(thrustForce, thrustPosition);
		// make sure to enable Gizmos in the GameWindow to see these
		Debug.DrawRay(thrustPosition, thrustForce, Color.red);
		Debug.Log("Force: " + thrustForce);
	}
}
