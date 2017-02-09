using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public GameObject installPanel1;//暂停窗口1
	public GameObject installPanel2;//暂停窗口2
	public GameObject stopPanel;//阻挡界面
	public GameObject playerJoystick;//控制主角摇杆
	private bool showWindow = false;
	void Start () {

	}

	void OnClick () {
		if (!showWindow) {
			PauseGame();
		}

	}
	//游戏暂停
	void PauseGame () {
		Time.timeScale = 0;
		//NGUITools.SetActive (installPanel1,true);//激活暂停窗口1
		NGUITools.SetActive (installPanel2,true);//激活暂停窗口2
		NGUITools.SetActive (stopPanel,true);
		playerJoystick.SetActive (false);
	}
}
