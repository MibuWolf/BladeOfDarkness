using UnityEngine;
using System.Collections;

public class BloodSaleButton : MonoBehaviour {

	public GameObject bloodSaleNumPanel;//血瓶售卖数量窗口
	public GameObject powerSaleNumPanel;//能量瓶售卖数量窗口
	public GameObject keySalePanel;//钥匙售卖窗口
	public GameObject newsPanel;//消息提示框

	void OnClick () {
		bloodSaleNumPanel.SetActive (true);
		powerSaleNumPanel.SetActive (false);
		keySalePanel.SetActive (false);
		newsPanel.SetActive (false);
	}
}
