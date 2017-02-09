using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	public GameObject installPanel;//暂停窗口
	public GameObject stopPanel;//遮挡界面
	public GameObject playerJoystick;//控制主角摇杆

	void Start () {
	
	}

	void OnClick () {
		NGUITools.SetActive (installPanel,false);
		NGUITools.SetActive (stopPanel,false);
		playerJoystick.SetActive (true);
		Time.timeScale = 1;
	}
}
