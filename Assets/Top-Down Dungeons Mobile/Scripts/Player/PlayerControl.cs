using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
	
	void OnDestroy(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
    }

	public Transform playerTransform;
	private Animator a;//定义角色控制器组件
	//private Transform enemy;
	//public GameObject hitPoint;

	public AudioClip footStep1;//脚步声一
	public AudioClip footStep2;//脚步声二

    void Awake () {
		a = GetComponent<Animator>();
		GameObject attackButton = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Sprite/AttackButton");
		UIEventListener.Get(attackButton).onPress = OnAttackButtonPress;
		GameObject skillOneButton = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill1");
		UIEventListener.Get(skillOneButton).onPress = OnSkillOneButtonPress;
		GameObject skillTwoButton = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill2");
		UIEventListener.Get(skillTwoButton).onPress = OnSkillTwoButtonPress;
		GameObject skillThreeButton = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill3");
		UIEventListener.Get(skillThreeButton).onPress = OnSkillThreeButtonPress;

		playerTransform = this.transform;
	}

	void Start () {

	}
	void Update () {

	}
	//执行按钮操作
	//攻击
	void OnAttackButtonPress (GameObject attackButton,bool isPressed) {
		if (isPressed) {
			a.SetBool("Attack",true);
			//hitPoint.SetActive(true);//激活武器与敌人的碰撞点
		}
		else {
			a.SetBool("Attack",false);
			//hitPoint.SetActive(false);//关闭武器与敌人的碰撞点
		}
	}
	//技能一
	void OnSkillOneButtonPress (GameObject skillOneButton,bool isPressed) {
		if (isPressed) {
			a.SetBool("Skill1",true);
			a.SetBool("Attack",false);
		}
		else {
			a.SetBool("Skill1",false);
		}
	}
	//技能二
	void OnSkillTwoButtonPress (GameObject skillTwoButton,bool isPressed) {
		if (isPressed) {
			a.SetBool("Skill2",true);
			a.SetBool("Attack",false);
		}
		else {
			a.SetBool("Skill2",false);
		}
	}
	//技能三
	void OnSkillThreeButtonPress (GameObject skillThreeButton,bool isPressed) {
		if (isPressed) {
			a.SetBool("Skill3",true);
			a.SetBool("Attack",false);
		}
		else {
			a.SetBool("Skill3",false);
		}
	}
	//摇杆控制行走
	void On_JoystickMove( MovingJoystick move) {
		
		float angle = move.Axis2Angle(true);
		playerTransform.transform.rotation  = Quaternion.Euler( new Vector3(0,angle-45,0));
		a.SetBool("Run",true);
		
	}
	void On_JoystickMoveEnd (MovingJoystick move) {
		a.SetBool("Run",false);
	}
	//行走脚步声
	void FootStepOne (bool isTrue) {
		if (isTrue) {
			GetComponent<AudioSource>().PlayOneShot(footStep1);
		}
	}
	void FootStepTwo (bool isTrue) {
		if (isTrue) {
			GetComponent<AudioSource>().PlayOneShot(footStep2);
		}
	}
}
