using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {
	private static float THRUSTER_POWER = 1.0f;
	public GameObject _mainRov;
	public GameObject _thrustOriginObject;
	public GameObject _thrustDirectionObject;

	private Rigidbody _rovRigidBody;
	// Use this for initialization
	void Start () {
		_rovRigidBody = _mainRov.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void powerThruster(float power) {
		if (power == 0) {
			return;
		}
		Vector3 thrustOrigin = _thrustOriginObject.transform.position;
		Vector3 thrustDirectionPoint = _thrustDirectionObject.transform.position;
		Vector3 thrustDirection = Vector3.Normalize(thrustDirectionPoint - thrustOrigin);
		Vector3 thrustForce = thrustDirection * THRUSTER_POWER * power;
		_rovRigidBody.AddForceAtPosition(thrustForce, thrustOrigin);
		// make sure to enable Gizmos in the GameWindow to see these
		Debug.DrawRay(thrustOrigin, thrustForce, Color.red);
	}
}
