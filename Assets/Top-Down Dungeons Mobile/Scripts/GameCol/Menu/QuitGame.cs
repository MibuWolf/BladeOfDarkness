using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	public GameObject stopPanel;
	public GameObject quitPanel;

	void OnClick () {
		NGUITools.SetActive (stopPanel,true);
		NGUITools.SetActive (quitPanel,true);
	}
}
