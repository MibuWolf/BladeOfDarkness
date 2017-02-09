using UnityEngine;
using System.Collections;

public class EnemyGirlAI : MonoBehaviour {

	public enum GirlState {
		idle,//站立
		fly,//飞行
		move,//移动
		attack1,//攻击1
		attack2,//攻击2
		dead,//死亡
		think,//思考
	}

	public float moveSpeed;//移动速度
	public float thinkTime;//思考时间
	public GirlState state = GirlState.idle;

	private Transform player;

	void Awake () {
		player = GameObject.FindWithTag(Tags.player).transform;
	}

	void Update () {
		switch(state) {
		case GirlState.idle:
			Idle ();
			break;
		case GirlState.fly:
			Fly ();
			break;
		case GirlState.move:
			Move ();
			break;
		case GirlState.attack1:
			Attack1 ();
			break;
		case GirlState.attack2:
			Attack2 ();
			break;
		case GirlState.dead:
			Dead ();
			break;
		case GirlState.think:
			Think ();
			break;
		default:
			break;
		}
	}

	void Idle () {

	}
	void Fly () {

	}
	void Move () {

	}
	void Attack1 () {

	}
	void Attack2 () {

	}
	void Dead () {

	}
	void Think () {

	}
}
