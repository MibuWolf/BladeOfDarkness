using UnityEngine;
using System.Collections;

public class Nobutton : MonoBehaviour {

	public GameObject stopPanel;
	public GameObject quitPanel;

	void OnClick () {
		NGUITools.SetActive (stopPanel,false);
		NGUITools.SetActive (quitPanel,false);
	}
}
