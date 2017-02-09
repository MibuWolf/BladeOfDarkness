using UnityEngine;
using System.Collections;

public class CloseHelpButton : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject stopPanel;

	void OnClick () {
		NGUITools.SetActive (helpPanel,false);
		NGUITools.SetActive (stopPanel,false);
	}
}
