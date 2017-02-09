using UnityEngine;
using System.Collections;

public class KeySaleButton : MonoBehaviour {

	public GameObject bloodSaleNumPanel;//血瓶售卖数量窗口
	public GameObject powerSaleNumPanel;//能量瓶售卖数量窗口
	public GameObject keySalePanel;//钥匙售卖窗口
	public GameObject newsPanel;//消息提示框
	
	void OnClick () {
		keySalePanel.SetActive (true);
		bloodSaleNumPanel.SetActive (false);
		powerSaleNumPanel.SetActive (false);
		newsPanel.SetActive (false);
	}
}
