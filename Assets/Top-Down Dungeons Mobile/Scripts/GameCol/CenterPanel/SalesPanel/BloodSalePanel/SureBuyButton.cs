using UnityEngine;
using System.Collections;

public class SureBuyButton : MonoBehaviour {

	public GameObject newsPanel;//消息提示框
	private NumLabel buyNum;//确定购买数量
	private BloodNum bloodNum;//血瓶数量变化
	private CoinsNum coinsNumber;//金币数量变化
	private bool isShow;//提示消息框是否显示

	void Awake () {
		GameObject numLabel = GameObject.Find ("UI Root/Camera/Anchor-Center/BloodSaleNumPanel/NumSprite/Label");
		buyNum = numLabel.gameObject.GetComponent<NumLabel>();
		GameObject blood = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Blood");
		bloodNum = blood.gameObject.GetComponent<BloodNum>();
		GameObject coin = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Coins");
		coinsNumber = coin.gameObject.GetComponent<CoinsNum>();
	}

	void OnClick () {
		if (coinsNumber.coinsNum >= buyNum.needCoinsNum ) {
			bloodNum.BloodNumberAdd (buyNum.num);
			//buyNum.num = 0;

			coinsNumber.CoinsNumAdd(-buyNum.needCoinsNum);
			//buyNum.needCoinsNum = 0;
		}
		else {
			newsPanel.SetActive (true);
			isShow = true;
		}
		buyNum.num = 0;
		buyNum.needCoinsNum = 0;
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
