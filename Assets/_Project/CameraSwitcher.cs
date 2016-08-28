using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
	public GameObject[] _cameraRigs;
	public int _cameraIndex = 0;

	// Use this for initialization
	void Start () {
		// disable all but the initial camera
		int i = Arrays.next(_cameraRigs, _cameraIndex);
		while (i != _cameraIndex) {
			Debug.Log("Deactivating camera " + i);
			_cameraRigs[i].SetActive(false);
			i = Arrays.next(_cameraRigs, i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(Buttons.SWITCH_CAMERA)) {
			int newIndex = Arrays.next(_cameraRigs, _cameraIndex);
			Debug.Log("Setting active camera to " + newIndex);
			_cameraRigs[newIndex].SetActive(true);
			_cameraRigs[_cameraIndex].SetActive(false);
			_cameraIndex = newIndex;
		}
	}
}
