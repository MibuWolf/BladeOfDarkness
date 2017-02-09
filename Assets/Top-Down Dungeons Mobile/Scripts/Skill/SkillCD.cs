using UnityEngine;
using System.Collections;

public class SkillCD : MonoBehaviour {
	//技能按钮CD特效
	UISprite sprite;
	public float cdTime;//CD时间
	private bool cd_bool = false;//是否处于技能cd中
	private float currentTime;//剩余CD时间
	private SphereCollider col;//技能按钮碰撞框
	private UILabel cdValue;//显示技能时间

	private Transform player;//定义主角
	private PlayerPower pPower;

	public float usePower;//能量消耗值

    void Awake () {
		sprite = GetComponentInChildren<UISprite>();
		sprite.fillAmount = 0;
		col = GetComponent<SphereCollider>();
		cdValue = GetComponentInChildren<UILabel>();

		player = GameObject.FindGameObjectWithTag (Tags.player).transform;//获取主角
		pPower = player.gameObject.GetComponent<PlayerPower>();//获取主角能量消耗脚本
	}
	void Start () {
		cdValue.enabled = false;//初始不显示技能时间文本
	}
	public void Click (bool canCD) {
		if (canCD == true) {
			if (cd_bool == false) {
				cdValue.enabled = true;
				col.enabled = false;
				cd_bool = true;
				sprite.fillAmount = 1;
				currentTime = cdTime;
				pPower.TakePower (usePower);//能量消耗
			}
		}

	}
	void Update () {
		//如果能量值小于能量消耗值，技能按钮无效
		if (pPower.realPower < -usePower) {
			col.enabled = false;
			sprite.fillAmount = 1;
		}
		//如果能量值大于等于能量消耗值，并且技能没有处于CD中，技能按钮有效
		if (pPower.realPower >= -usePower) {
			if (cd_bool == false) {
				col.enabled = true;
				sprite.fillAmount = 0;
			}
		}
		if (cd_bool) {
			currentTime -= Time.deltaTime;
			cdValue.text = string.Format("{0}",(int)currentTime);
			if (currentTime < 0) {
				currentTime = 0;
			}
			sprite.fillAmount = currentTime/cdTime;
			if (sprite.fillAmount == 0) {
				cd_bool = false;
				col.enabled = true;
				cdValue.enabled = false;
			}
		}
	}
}
