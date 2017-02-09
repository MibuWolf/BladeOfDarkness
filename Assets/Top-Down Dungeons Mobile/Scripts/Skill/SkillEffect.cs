using UnityEngine;
using System.Collections;

public class SkillEffect : MonoBehaviour {

	public LayerMask ignoreLayers;//碰撞层
	public GameObject skillEffectPrefab;//技能特效
	public float radius;//产生的碰撞球半径
	public bool collided = false;//是否发生碰撞

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//碰撞监测
		Collider[] hits = Physics.OverlapSphere(transform.position,radius,~ignoreLayers);
		foreach (Collider c in hits) {
			if (c.isTrigger) {
				continue;
			}
			collided = true;
		}
		if (collided) {
			Destroy(this.gameObject);
			Instantiate(skillEffectPrefab,transform.position,transform.rotation);
		}
	}
}
