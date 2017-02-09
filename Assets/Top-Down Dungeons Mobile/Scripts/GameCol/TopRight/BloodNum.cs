using UnityEngine;
using System.Collections;

public class BloodNum : MonoBehaviour {

	UISprite bloodSprite;
	private float bloodCDTime;//血瓶cd时间
	private bool cd_bool = false;
	private float currentBloodCDTime;//剩余cd时间
	private BoxCollider col;//血瓶按钮碰撞框
	private UILabel bloodNum;

	private PlayerHealth ph;
	private Transform player;
	
	public int bloodNumber;//血瓶数量
	public float bloodAdd;//加血值
	
	void Awake () {
		bloodSprite = GetComponentInChildren<UISprite>();
		bloodNum = GetComponentInChildren<UILabel>();
		bloodSprite.fillAmount = 0;
		col = GetComponent<BoxCollider>();
		bloodCDTime = 4f;
		bloodNum.text = string.Format("x{0}",bloodNumber);
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		ph = player.gameObject.GetComponent<PlayerHealth>();
	}

	void Update () {
		if (cd_bool) {
			currentBloodCDTime -= Time.deltaTime;
			bloodNum.text = string.Format("x{0}",bloodNumber);
			if (currentBloodCDTime < 0) {
				currentBloodCDTime = 0;
			}
			bloodSprite.fillAmount = currentBloodCDTime/bloodCDTime;
			if (bloodSprite.fillAmount == 0) {
				cd_bool = false;
				col.enabled = true;
			}
			if (bloodNumber <= 0) {
				bloodNumber = 0;
				col.enabled = false;
			}
		}
		bloodNum.text = string.Format("x{0}",bloodNumber);
	}
	void OnClick () {
		if (cd_bool == false) {
			col.enabled = false;
			cd_bool = true;
			bloodSprite.fillAmount = 1;
			currentBloodCDTime = bloodCDTime;
			bloodNumber --;
		}
		ph.TakeBlood(bloodAdd);
	}
	//血瓶数量变化
	public void BloodNumberAdd (int num) {
		bloodNumber += num;
	}
}
