using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public GameObject soundPanel;
	public GameObject installPanel;
	void Start () {
	
	}

	void OnClick () {
		NGUITools.SetActive(soundPanel,false);
		NGUITools.SetActive(installPanel,true);
		Time.timeScale = 0;
	}
}
