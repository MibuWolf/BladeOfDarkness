using UnityEngine;
using System.Collections;

public class BloodUI : MonoBehaviour {

	private UISprite bloodUI;//定义血条UI
	private UILabel bloodText;//定义显示血量值文本
	private float maxBlood;//最大血量值
	private float realBlood;//真实血量值
	private Transform player;//定义玩家
	private PlayerHealth ph;

	void Awake () {
		bloodUI = GetComponent<UISprite>();//初始化血条UI
		bloodText = GetComponentInChildren<UILabel>();//初始化显示血量值文本
		bloodUI.fillAmount = 1;//初始血条比值
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;//获取玩家
		ph = player.gameObject.GetComponent<PlayerHealth>();//获取玩家生命脚本
	}

	void Start () {
		maxBlood = ph.playerHealth;
	}

	void Update () {
		bloodUI.fillAmount = ph.bloodPercent;
		realBlood = ph.bloodPercent*maxBlood;
		bloodText.text = string.Format("{0}/{1}",(int)realBlood,maxBlood);
	}
}
