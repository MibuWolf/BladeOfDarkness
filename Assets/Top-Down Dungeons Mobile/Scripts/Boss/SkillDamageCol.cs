using UnityEngine;
using System.Collections;

public class SkillDamageCol : MonoBehaviour {

	public LayerMask playerMask;
	public float radius;
	public bool collided = false;
	public float damageCount;
	
	private Transform player;
	private PlayerHealth ph;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		ph = player.gameObject.GetComponent<PlayerHealth>();
	}
	void Update () {
		WeapCol ();
	}
	void WeapCol () {
		Collider[] hits = Physics.OverlapSphere(transform.position,radius,playerMask);
		foreach (Collider c in hits) {
			if (c.isTrigger) {
				continue;
			}
			collided = true;
			if (collided) {
				ph.TakeBlood(damageCount);
				Destroy(gameObject);
			}
		}
	}
}
