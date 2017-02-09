using UnityEngine;
using System.Collections;

public class BossStartMove : MonoBehaviour {

	private SphereCollider col;
	private Transform boss;
	private BossAI ba;

	void Awake () {
		col = gameObject.GetComponent<SphereCollider>();
		boss = GameObject.FindWithTag (Tags.boss).transform;
		ba = boss.GetComponent<BossAI>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerNinja") {
			ba.enabled = true;
			col.enabled = false;
		}
	}
}
