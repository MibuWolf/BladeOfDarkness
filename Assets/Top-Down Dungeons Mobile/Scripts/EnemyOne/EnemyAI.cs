using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform enemyTransform;
	public Transform[] navMeshTransforms;//导航网格的目的地组
	public float chaseSpeed;
	private int wayPointIndex;//巡逻点索引
	private UnityEngine.AI.NavMeshAgent enemy;//定义导航网格
	private CapsuleCollider col;//定义敌人本身碰撞胶囊体
	private Transform player;//定义主角
	private Animator anim;//定义动画控制器组件
	private EnemyHealth eh;
	private PlayerHealth ph;
	private bool victory;//判断敌人是否执行胜利动画
	//private PlayerControl playerControl;//定义主角脚本

	// Use this for initialization
	void Start () {
		col = gameObject.GetComponent<CapsuleCollider>();//获得碰撞胶囊组件
        anim = gameObject.GetComponent<Animator>();//获取角色控制器组件
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;//获取主角对象
		if (navMeshTransforms == null) {
			return;
		}
		enemy = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();//获取导航网格组件
		enemy.SetDestination(navMeshTransforms[0].position);//初始时刻设置的导航网格代理的目的地
		//playerControl = GetComponent<PlayerControl>();//获取主角脚本
		enemyTransform = this.transform;
		eh = this.gameObject.GetComponent<EnemyHealth>();//获得本身生命脚本
		ph = player.gameObject.GetComponent<PlayerHealth>();
	}

	void Update () {
		float distance = Vector3.Distance(enemyTransform.transform.position,player.transform.position);//敌人与玩家的距离
		//如果敌人血量大于0
		if (eh.realHealth > 0) {
			//距离大于7，执行巡逻并自动寻路
			if (distance > 7f) {
				Patrol();
				enemy.Resume ();//继续寻路
			}
			else {
				enemy.Stop ();//停止寻路
				//距离大于2.5小于7，开始追逐
				if (distance > 2.5f) {
					Chase ();
				}
				else {
					//距离小于2.5，开始攻击
					Attack();
				}
				transform.LookAt(player);//始终朝向主角
			}
		}
		//如果敌人死亡，停止一切活动，碰撞胶囊关闭
		if (eh.realHealth <= 0) {
			enemy.Stop ();
			col.enabled = false;
		}
		//如果玩家死亡，敌人执行胜利动画，这里胜利动画只设定成了站立
		if (ph.realHealth <= 0) {
			EnemyVictory ();
		}
		//如果敌人执行了胜利动画,敌人不再执行胜利动画
		if (victory == true) {
			EnemyIsVictory();
		}
	}
    //巡逻
	void Patrol () {
		if (enemy.remainingDistance == 0) {
			anim.SetFloat("Speed",0f);
			anim.SetBool("Attack",false);
			anim.SetBool("Run",false);
			if (wayPointIndex == navMeshTransforms.Length - 1) {
				wayPointIndex = 0;
			}
			else {
				wayPointIndex++;
			}
			enemy.destination = navMeshTransforms[wayPointIndex].position;
		}
		else {
			anim.SetFloat("Speed",1f);
			anim.SetBool("Attack",false);
			anim.SetBool("Run",false);

		}
		
	}
	//追逐
	void Chase () {
		anim.SetBool("Run",true);
		anim.SetFloat("Speed",chaseSpeed);
		anim.SetBool("Attack",false);
	}
	//攻击
	void Attack () {
		anim.SetBool("Attack",true);
	}
	//敌人胜利
	void EnemyVictory () {
		anim.SetBool("Victory",true);
		victory = true;
		enemy.Stop ();
	}
	//防止敌人执行胜利动画后再次过渡到胜利动画
	void EnemyIsVictory () {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stand")) {
			anim.SetBool("Victory",false);
		}
	}
}