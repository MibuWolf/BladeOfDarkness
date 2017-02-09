using UnityEngine;
using System.Collections;

public class NoTomenubutton : MonoBehaviour {

	public GameObject installPanel;//游戏设置窗口
	public GameObject backToMenuPanel;//选择是否返回游戏菜单窗口

	void OnClick () {
		NGUITools.SetActive (installPanel,true);
		NGUITools.SetActive (backToMenuPanel,false);
	}
}
