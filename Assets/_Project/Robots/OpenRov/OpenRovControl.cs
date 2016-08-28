using UnityEngine;
using System.Collections;

public class OpenRovControl : MonoBehaviour {
	public GameObject _verticalThrusterMarker;
	public GameObject _starboardThrusterMarker;
	public GameObject _portThrusterMarker;

	private Rigidbody _rovRigidBody;
	// TODO make thrust private?
	public float _thrustPower;
	public float _rayDistance;
	// Use this for initialization
	void Start () {
		_rovRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis(Axes.HORIZONTAL);
		powerThruster(_starboardThrusterMarker, horizontal);
		powerThruster(_portThrusterMarker, -1 * horizontal);

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
		_rovRigidBody.AddForceAtPosition(thrustForce, thrustPosition);
		Debug.Log("Apply " + thrustForce + " at " + thrustPosition);
		Debug.DrawRay(thrustPosition, thrustDirection * _rayDistance, Color.red, .1f);
	}
}
