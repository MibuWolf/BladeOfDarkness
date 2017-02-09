using UnityEngine;
using System.Collections;

public class EnemyInstance : MonoBehaviour {

	public GameObject longjuanfeng;//实例敌人对象时的龙卷风特效
	public GameObject enemy;//敌人
	public GameObject enemyInstantPoint;//敌人产生点
	public float destoryTime;//敌人产生点销毁时间
	public AudioClip windSound;//龙卷风声音

	private CapsuleCollider enemyCol;//当前敌人碰撞胶囊
	private EnemyAI enemyAI;//敌人AI脚本

	void Start () {
		enemyCol = enemy.gameObject.GetComponent<CapsuleCollider>();//获取当前敌人碰撞胶囊
		enemyAI = enemy.gameObject.GetComponent<EnemyAI>();//获取当前敌人AI脚本组件
	}
	//实例敌人对象的触发器
	void OnTriggerEnter (Collider col) {
		if (col.tag == "PlayerNinja") {
			Instantiate(longjuanfeng,enemyInstantPoint.transform.position,enemyInstantPoint.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(windSound);
			StartCoroutine(EnemyInstant());
			Destroy(enemyInstantPoint,destoryTime);
		}
	}
	//敌人对象延时1秒产生
	IEnumerator EnemyInstant () {
		yield return new WaitForSeconds (1);
		Instantiate(enemy,enemyInstantPoint.transform.position,enemyInstantPoint.transform.rotation);
	}
}
