using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth;//玩家生命值
	public float realHealth;//玩家真实生命值
	public float bloodPercent;//初始生命值百分比

	private Animator a;
	//private float timer;
	private bool playerDead;//判定玩家是否执行死亡动作
	private bool playerBeHit;//判定玩家是否执行被攻击动作

	public GameObject redPanel;//受伤时屏幕变红UI对象
	private UIPanel redPanelUI;
	public float redPanelCurrentTime;//屏幕变淡剩余时间
	public float redPanelTime;//屏幕变淡总时间

	public GameObject losePanel;//游戏失败界面
	public GameObject finallyStopPanel;//透明阻挡界面
	public GameObject joystick;//虚拟摇杆

	private BossHealth bh;
	private Transform boss;
	private bool victory;//是否胜利

	void Awake () {
		a = GetComponent<Animator>();
		redPanelUI = redPanel.gameObject.GetComponent<UIPanel>();//获取受伤时屏幕变红UI的脚本
		redPanelUI.alpha = 0;//初始透明度为0

		boss = GameObject.FindWithTag(Tags.boss).transform;//获取boss
		bh = boss.gameObject.GetComponent<BossHealth>();//获取boss生命脚本
	}

	void Update () {
		//如果血量为0，执行死亡动画
		if (realHealth <= 0) {
			realHealth = 0;
			PlayerDying ();
		}
		//执行防止过渡到死亡动画
		if (playerDead == true) {
			PlayerDead();
		}
		//if (playerBeHit == true) {
			//PlayerHiting();
		//}
		//if (playerBeHit == false) {
			//PlayerHit();
		//}
		//如果血量大于100，设定血量为满血100
		if (realHealth >= 100) {
			realHealth = 100;
		}
		bloodPercent =(int)realHealth/playerHealth;//更新血量百分比
		//如果redPanelUI的透明度值大于0，透明度逐渐变0
		if (redPanelUI.alpha > 0) {
			redPanelUI.alpha -= Time.deltaTime;
		}

		//如果boss血量为0，执行胜利动画
		if (bh.bossRealHealth <= 0) {
			Victory ();
		}
		//如果已经执行胜利动画，则不再执行胜利动画
		if (victory == true) {
			VictoryEnd ();
		}
	}
	//死亡
	void PlayerDying () {
		playerDead = true;
		a.SetBool("Dead",true);
		losePanel.SetActive(true);
		finallyStopPanel.SetActive (true);
		joystick.SetActive (false);
		//a.SetBool("BeAttack",false);
		a.SetBool("Attack",false);
	}
	//防止AnyState过渡到死亡动画后再次执行死亡动作
	void PlayerDead () {
		if (a.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Dying")) {
			a.SetBool("Dead",false);
		}
	}
	//血量变化
	public void TakeBlood (float amount) {
		realHealth += amount;
		if (amount < 0) {
			//playerBeHit = true;//玩家收到攻击为真
			redPanelUI.alpha = redPanelCurrentTime/redPanelTime;
		}
	}
	//胜利
	void Victory () {
		a.SetBool ("Victory",true);
		victory = true;//胜利
	}
	//防止再次执行胜利动画
	void VictoryEnd () {
		if (a.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Victory")) {
			a.SetBool("Victory",false);
		}
	}
	//玩家被攻击
	//void PlayerHiting () {
		//playerBeHit = false;
		//a.SetBool("BeAttack",true);
		//a.SetBool("Attack",false);
	//}
	//防止AnyState过渡到受攻击动画后再次执行受攻击动作
	//void PlayerHit () {
		//if (a.GetCurrentAnimatorStateInfo(0).IsName ("Base Layer.Hit")) {
			//a.SetBool("BeAttack",false);
		//}
	//}
}
