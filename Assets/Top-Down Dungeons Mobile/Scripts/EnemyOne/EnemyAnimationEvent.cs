using UnityEngine;
using System.Collections;

public class EnemyAnimationEvent : MonoBehaviour {

	public GameObject attackPointOne;//攻击点一
	public GameObject attackPointTwo;//攻击点二
	public GameObject enemyAttackEffectPrefab;//攻击特效
	//攻击一产生特效
	void EnemyAttackOne () {
		Instantiate(enemyAttackEffectPrefab,attackPointOne.transform.position,attackPointOne.transform.rotation);
	}
	//攻击二产生特效
	void EnemyAttackTwo () {
		Instantiate(enemyAttackEffectPrefab,attackPointTwo.transform.position,attackPointTwo.transform.rotation);
	}
	//激活攻击点一
	void EnemyAttackOneStart () {
		attackPointOne.SetActive(true);
	}
	//关闭攻击点一
	void EnemyAttackOneEnd () {
		attackPointOne.SetActive(false);
	}
	//激活攻击点二
	void EnemyAttackTwoStart () {
		attackPointTwo.SetActive(true);
	}
	//关闭攻击点二
	void EnemyAttackTwoEnd () {
		attackPointTwo.SetActive(false);
	}
}
