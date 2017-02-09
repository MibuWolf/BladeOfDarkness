using UnityEngine;
using System.Collections;

public class SkillDamage : MonoBehaviour {

	public LayerMask ignoreLayers;//碰撞层
	public float radius;//碰撞球半径
	public bool collided = false;//是否发生碰撞
	public float damageCount;//伤害值
	public EnemyHealth attackTarget;//攻击对象
	public GameObject damageEffect;//伤害特效
	
	void Update () {
		//碰撞监测
		Collider[] hits = Physics.OverlapSphere(transform.position,radius,ignoreLayers);
		foreach (Collider c in hits) {
			if (c.isTrigger) {
				continue;
			}
			attackTarget = c.GetComponent<Collider>().gameObject.GetComponent<EnemyHealth>();//获得当前碰撞对象的生命脚本
			collided = true;
			if (collided) {
				Instantiate(damageEffect,transform.position,transform.rotation);
				attackTarget.EnemyTakeBlood(damageCount);
			}
		}
	}
}
