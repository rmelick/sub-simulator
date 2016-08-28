using UnityEngine;
using System.Collections;

public class OpenRovControl : MonoBehaviour {
	public Thruster _verticalThruster;
	public Thruster _portThruster;
	public Thruster _starboardThruster;

	// TODO make thrust power private?
	public float _thrustPower;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
