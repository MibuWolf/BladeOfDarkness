using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

	public GameObject stopPanel;
	public GameObject helpPanel;

	void OnClick () {
		NGUITools.SetActive (helpPanel,true);
		NGUITools.SetActive (stopPanel,true);
	}
}
