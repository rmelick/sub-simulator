using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSelector : MonoBehaviour {
	private string _currentSceneToLoad;
	

	void Start() {
		_currentSceneToLoad = "Pool1Scene";
	}	

	public void LoadScene() {
		SceneManager.LoadScene(_currentSceneToLoad);
	}
}
