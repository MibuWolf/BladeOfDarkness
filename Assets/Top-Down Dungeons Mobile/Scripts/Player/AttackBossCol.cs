using UnityEngine;
using System.Collections;

public class AttackBossCol : MonoBehaviour {

	public LayerMask ignoreLayers;//碰撞层
	public float radius;//碰撞球半径
	public GameObject attackEffectPrefab;//碰撞产生的特效
	public bool collided = false;//是否发生碰撞
	public Transform hitPoint;//碰撞点
	public float damageCount;//伤害值

	public BossHealth bh;
	private Transform boss;
	
	void Awake () {
		//boss = GameObject.FindWithTag(Tags.boss).transform;
		//bh = boss.gameObject.GetComponent<BossHealth>();
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
			bh = c.GetComponent<Collider>().gameObject.GetComponent<BossHealth>();
			collided = true;
			if (collided) {
				Instantiate(attackEffectPrefab,hitPoint.transform.position,hitPoint.transform.rotation);
				bh.BossTakeBlood (damageCount);
			}
		}
	}
}
