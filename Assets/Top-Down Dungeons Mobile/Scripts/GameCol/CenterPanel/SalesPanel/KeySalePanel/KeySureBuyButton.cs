using UnityEngine;
using System.Collections;

public class KeySureBuyButton : MonoBehaviour {

	public GameObject newsPanel;//消息提示框
	private NumLabel buyNum;//确定购买数量
	private KeyNum keyNum;//钥匙数量变化
	private Stones stonesNumber;//宝石数量变化
	private bool isShow;//提示消息框是否显示
	
	void Awake () {
		GameObject numLabel = GameObject.Find ("UI Root/Camera/Anchor-Center/KeySaleNumPanel/NumSprite/Label");
		buyNum = numLabel.gameObject.GetComponent<NumLabel>();
		GameObject key = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Key");
		keyNum = key.gameObject.GetComponent<KeyNum>();
		GameObject stone = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Stones");
		stonesNumber = stone.gameObject.GetComponent<Stones>();
	}
	
	void OnClick () {
		if (stonesNumber.stonesNum >= buyNum.needStonesNum ) {
			keyNum.KeyNumAdd (buyNum.num);
			stonesNumber.StonesNumAdd (-buyNum.needStonesNum);
		}
		else {
			newsPanel.SetActive (true);
			isShow = true;
		}
		buyNum.num = 0;
		buyNum.needStonesNum = 0;
	}
	
	void Update () {
		if (isShow == true) {
			StartCoroutine (CloseWaitTime ());
			isShow = false;
		}
	}
	//提示消息框消失等待
	IEnumerator CloseWaitTime () {
		yield return new WaitForSeconds(2);
		newsPanel.SetActive (false);
		//isShow = false;
	}
}
