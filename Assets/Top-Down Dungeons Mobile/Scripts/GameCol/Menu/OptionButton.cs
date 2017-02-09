using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour {

	public GameObject optionPanel;
	public GameObject stopPanel;

	void OnClick () {
		NGUITools.SetActive (optionPanel,true);
		NGUITools.SetActive (stopPanel,true);
	}

}
