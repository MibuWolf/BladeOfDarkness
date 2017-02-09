using UnityEngine;
using System.Collections;

public class InstallButton : MonoBehaviour {

	public GameObject soundPanel;
	public GameObject installPanel;
	private bool paused;
	void Start () {
	
	}
	void Update () {

	}
	void OnClick () {
		NGUITools.SetActive (soundPanel,true);
		NGUITools.SetActive (installPanel,false);
		//Time.timeScale = 0;
		Object[] objects = FindObjectsOfType(typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage("OnPauseGame",SendMessageOptions.DontRequireReceiver);
		}
	}
	void OnPauseGame () {
		paused = true;
	}
}
