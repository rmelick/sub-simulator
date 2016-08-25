using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
	public GameObject[] cameraRigs;
	public int cameraIndex = 0;

	// Use this for initialization
	void Start () {
		// disable all but the initial camera
		int i = Arrays.next(cameraRigs, cameraIndex);
		while (i != cameraIndex) {
			Debug.Log("Deactivating camera " + i);
			cameraRigs[i].SetActive(false);
			i = Arrays.next(cameraRigs, i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(Buttons.SWITCH_CAMERA)) {
			int newIndex = Arrays.next(cameraRigs, cameraIndex);
			Debug.Log("Setting active camera to " + newIndex);
			cameraRigs[newIndex].SetActive(true);
			cameraRigs[cameraIndex].SetActive(false);
			cameraIndex = newIndex;
		}
	}
}
