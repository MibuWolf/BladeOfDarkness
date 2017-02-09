using UnityEngine;
using System.Collections;

public class AttackCol : MonoBehaviour {

	public LayerMask ignoreLayers;//碰撞层
	public float radius;//碰撞球半径
	public GameObject attackEffectPrefab;//碰撞产生的特效
	public bool collided = false;//是否发生碰撞
	public Transform hitPoint;//碰撞点
	public float damageCount;//伤害值
	public EnemyHealth attackTarget;//攻击对象

	void Awake () {

	}
	void Update () {
		WeapCol ();
	}
    void WeapCol () {
		//碰撞监测
		Collider[] hits = Physics.OverlapSphere(hitPoint.transform.position,radius,ignoreLayers);
		foreach (Collider c in hits) {
			if (c.isTrigger) {
				continue;
			}

			attackTarget = c.GetComponent<Collider>().gameObject.GetComponent<EnemyHealth>();//获得当前碰撞对象的生命脚本
			collided = true;
			if (collided) {
				Instantiate(attackEffectPrefab,hitPoint.transform.position,hitPoint.transform.rotation);
				attackTarget.EnemyTakeBlood(damageCount);
			}
		}
	}
}
