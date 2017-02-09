using UnityEngine;
using System.Collections;

public class EnemyAttackCol : MonoBehaviour {

	public LayerMask playerMask;
	public float radius;
	public bool collided = false;
	public Transform hitPoint;
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
		Collider[] hits = Physics.OverlapSphere(hitPoint.transform.position,radius,playerMask);
		foreach (Collider c in hits) {
			if (c.isTrigger) {
				continue;
			}
			collided = true;
			if (collided) {
				ph.TakeBlood(damageCount);
			}
		}
	}
}
