using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	private Animator boss;
	private Transform player;
	private PlayerHealth ph;
	private BossHealth bh;

	void Awake () {
		boss = gameObject.GetComponent<Animator>();
		player = GameObject.FindWithTag(Tags.player).transform;
		ph = player.gameObject.GetComponent<PlayerHealth>();
		bh = gameObject.GetComponent<BossHealth>();
	}

	void Update () {
		float distance = Vector3.Distance(player.transform.position,transform.position);
		if (bh.bossRealHealth > 0) {
			transform.LookAt(player);
		}
		if (ph.realHealth <= 0) {
			boss.SetBool ("Skill1",false);
			boss.SetBool ("Skill2",false);
			boss.SetBool ("Skill3",false);
			boss.SetBool ("Walk",false);
		}
		if (ph.realHealth > 0) {
			if (distance > 5) {
				boss.SetBool("Walk",true);
				boss.SetBool ("Skill1",false);
				boss.SetBool ("Skill2",false);
				boss.SetBool ("Skill3",false);
			}
			else {
				boss.SetBool("Walk",false);
				if (distance > 2.5) {
					boss.SetBool("Skill1",true);
					boss.SetBool("Skill2",false);
					boss.SetBool("Skill3",false);
				}
				if (distance <= 2.5 && distance > 0.5) {
					boss.SetBool ("Skill2",true);
					boss.SetBool("Skill3",false);
					boss.SetBool("Skill1",false);
				}
				if (distance <= 0.5) {
					boss.SetBool ("Skill3",true);
					boss.SetBool("Skill2",false);
					boss.SetBool("Skill1",false);
				}
			}
		}

	}

}