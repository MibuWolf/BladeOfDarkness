using UnityEngine;
using System.Collections;

public class EnemyBloodUI : MonoBehaviour {

	UISprite enemyBloodUI;
	private EnemyHealth eh;
	private Transform nowEnemy;//当前敌人对象

	void Awake () {
		enemyBloodUI = GetComponent<UISprite>();
		enemyBloodUI.fillAmount = 1;
		nowEnemy = GameObject.FindGameObjectWithTag (Tags.enemy).transform;
		eh = nowEnemy.gameObject.GetComponent<EnemyHealth>();
	}

	void Update () {
		//enemyBloodUI.fillAmount = eh.bloodPercent;
	}
}
