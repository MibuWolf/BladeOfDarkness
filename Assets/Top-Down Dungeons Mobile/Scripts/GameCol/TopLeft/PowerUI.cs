using UnityEngine;
using System.Collections;

public class PowerUI : MonoBehaviour {

	private UISprite powerUI;//定义能量UI
	//private float maxPower;//最大能量值
	//private float realPower;//真实能量值
	private Transform player;
	private PlayerPower pp;

	void Awake () {
		powerUI = GetComponent<UISprite>();//初始化能量UI
		powerUI.fillAmount = 1;
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;//获取玩家
		pp = player.gameObject.GetComponent<PlayerPower>();//获取玩家能量脚本
	}
	void Start () {
		//maxPower = pp.playerPower;
	}

	void Update () {
		powerUI.fillAmount = pp.powerPercent;
		//realPower = pp.powerPercent*maxPower;
	}
}
