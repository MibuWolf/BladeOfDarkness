using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public float enemyHealth;//敌人血量值
	public float realHealth;//敌人真实血量值
	public float bloodPercent;//初始血量比值
	public AudioClip enemyDeadSound;//敌人死亡声音

	private bool enemyDead;//敌人是否死亡
	private Animator anim;//定义敌人角色动画
	private bool enemyBeHit;//敌人是否收到攻击

	public GameObject deadEffectPrefab;//死亡后特效
	public Transform deadEffectPoint;//死亡特效产生点

	public GameObject attackPointOne;//攻击点一
	public GameObject attackPointTwo;//攻击点二

	public GameObject coins;//死亡掉落的金币

	void Awake () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		bloodPercent = (int)realHealth/enemyHealth;

		if (enemyDead == true) {
			EnemyDead ();
		}
		if (enemyBeHit == true) {
			EnemyHiting ();
		}
		if (enemyBeHit == false) {
			EnemyHit ();
		}
	}
	//敌人死亡
	void EnemyDying () {
		anim.SetBool("Dead",true);
		anim.SetBool("BeAttacked",false);
		enemyDead = true;
		StartCoroutine(DeadEffect ());
		attackPointOne.SetActive(false);
		attackPointTwo.SetActive(false);
		GetComponent<AudioSource>().PlayOneShot (enemyDeadSound);
	}
	//防止AnyState过渡到死亡动画后再次执行死亡动作
	void EnemyDead () {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Dying")) {
			anim.SetBool("Dead",false);
		}
	}
	//接收伤害
	public void EnemyTakeBlood (float amount) {
		realHealth -= amount;
		if (realHealth <= 0) {
			realHealth = 0;
			EnemyDying ();
		}

		if (amount > 0) {
			enemyBeHit = true;
		}
	}
	//敌人被攻击
	void EnemyHiting () {
		enemyBeHit = false;
		anim.SetBool("BeAttacked",true);
		anim.SetBool("Attack",false);
		transform.Translate (Vector3.back*0.5f);
	}
	//防止AnyState过渡到受攻击动画后再次执行受攻击动作
	void EnemyHit () {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Hit")) {
			anim.SetBool("BeAttacked",false);
		}
	}

	IEnumerator DeadEffect () {
		yield return new WaitForSeconds(2);
		Instantiate(deadEffectPrefab,deadEffectPoint.transform.position,deadEffectPoint.transform.rotation);
		Destroy(gameObject);
		Instantiate(coins,transform.position,transform.rotation);
	}
}
