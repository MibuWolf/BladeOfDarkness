using UnityEngine;
using System.Collections;

public class LeaveButton : MonoBehaviour {

	public GameObject backToMenuPanel;//选择是否返回游戏菜单窗口
	public GameObject installPane;//游戏设置窗口

	void OnClick () {
		NGUITools.SetActive (backToMenuPanel,true);
		NGUITools.SetActive (installPane,false);
	}
}
