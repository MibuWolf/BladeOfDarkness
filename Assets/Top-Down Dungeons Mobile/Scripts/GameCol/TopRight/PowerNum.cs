using UnityEngine;
using System.Collections;

public class PowerNum : MonoBehaviour {

	UISprite powerSprite;
	private float powerCDTime;//能量瓶cd时间
	private bool cd_bool = false;
	private float currentPowerCDTime;//剩余cd时间
	private BoxCollider col;//能量瓶按钮碰撞框
	private UILabel powerNum;

	private Transform player;
	private PlayerPower pp;

	public int powerNumber;//能量瓶数量
	public float powerAdd;//加能量值

	void Awake () {
		powerSprite = GetComponentInChildren<UISprite>();
		powerNum = GetComponentInChildren<UILabel>();
		powerSprite.fillAmount = 0;
		col = GetComponent<BoxCollider>();
		powerCDTime = 4f;
		powerNum.text = string.Format("x{0}",powerNumber);
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		pp = player.gameObject.GetComponent<PlayerPower>();
	}

	void Update () {
		if (cd_bool) {
			currentPowerCDTime -= Time.deltaTime;
			powerNum.text = string.Format("x{0}",powerNumber);
			if (currentPowerCDTime < 0) {
				currentPowerCDTime = 0;
			}
			powerSprite.fillAmount = currentPowerCDTime/powerCDTime;
			if (powerSprite.fillAmount == 0) {
				cd_bool = false;
				col.enabled = true;
			}
			if (powerNumber <= 0) {
				powerNumber = 0;
				col.enabled = false;
				//powerSprite.fillAmount = 1;
			}
		}
		powerNum.text = string.Format("x{0}",powerNumber);
	}
	void OnClick () {
		if (cd_bool == false) {
			col.enabled = false;
			cd_bool = true;
			powerSprite.fillAmount = 1;
			currentPowerCDTime = powerCDTime;
			powerNumber --;
		}
		pp.TakePower(powerAdd);
	}
	//能量瓶数量变化
	public void PowerNumAdd (int num) {
		powerNumber += num;
	}
}
