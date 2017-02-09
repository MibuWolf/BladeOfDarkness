using UnityEngine;
using System.Collections;

public class AttributeButton : MonoBehaviour {

	public GameObject attributePanel;//角色属性面板
	public GameObject stopPanel;//遮挡面板
	public GameObject playerJoyStick;//摇杆

	void OnClick () {
		NGUITools.SetActive (attributePanel,true);
		NGUITools.SetActive (stopPanel,true);
		playerJoyStick.SetActive (false);
		Time.timeScale = 0;
	}
}
