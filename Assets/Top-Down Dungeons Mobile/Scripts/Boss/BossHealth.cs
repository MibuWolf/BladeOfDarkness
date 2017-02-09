using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public float bossRealHealth;
	public float bossHealth;
	public float bloodPercent;
	public AudioClip bossDeadSound;

	private Animator boss;
	private bool isDead;
	private CapsuleCollider bossCol;

	public GameObject finallyStopPanel;
	public GameObject victoryPanel;
	public GameObject joystick;

	void Awake () {
		boss = gameObject.GetComponent<Animator>();
		bossCol = gameObject.GetComponent<CapsuleCollider>();
	}
	void Update () {
		bloodPercent = (int)bossRealHealth/bossHealth;
		if (isDead == true) {
			BossDead ();
		}
	}
	//Boss死亡
	void BossDying () {
		boss.SetBool("Dead",true);
		isDead = true;
		bossCol.enabled = false;
		GetComponent<AudioSource>().PlayOneShot (bossDeadSound);
		victoryPanel.SetActive (true);
		finallyStopPanel.SetActive (true);
		joystick.SetActive (false);
	}
	//防止再次执行死亡动画
	void BossDead () {
		if (boss.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Dead")) {
			boss.SetBool("Dead",false);
		}
	}
	public void BossTakeBlood (float amount) {
		bossRealHealth -= amount;
		if (bossRealHealth <= 0) {
			bossRealHealth = 0;
			BossDying ();
		}
	}
}
