using UnityEngine;
using System.Collections;

public class CloseButton : MonoBehaviour {

	public GameObject optionPanel;
	public GameObject stopPanel;

	void OnClick () {
		NGUITools.SetActive (optionPanel,false);
		NGUITools.SetActive (stopPanel,false);
	}
}
