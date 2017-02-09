using UnityEngine;
using System.Collections;

public class SwordTrail : MonoBehaviour {

	private MeleeWeaponTrail weaponTrail;//武器拖尾
	private Transform sword;//刀

	public GameObject hitPoint;//武器与敌人的碰撞点
	public GameObject slashThreeEffectPrefab;//连招中的第三招特效
	public Transform slashThreePoint;//特效产生点

	public AudioClip swordHit1;//连招一音效
	public AudioClip swordHit2;//连招二音效
	public AudioClip earthHitMusic;//连招三音效
	public AudioClip jiaoHanSheng;//叫喊声

	public AudioClip playerDeadSound;//主角死亡声音

	//private Transform playerCamera;//主角摄像机
	//private AttachCamera cameraShake;

	void Awake () {
		sword = GameObject.FindGameObjectWithTag(Tags.sword).transform;//获取刀
		weaponTrail = sword.gameObject.GetComponent<MeleeWeaponTrail>();//获取武器拖尾脚本

		//playerCamera = GameObject.FindWithTag(Tags.playerCamera).transform;
		//cameraShake = playerCamera.gameObject.GetComponent<AttachCamera>();
	}
	//连招第一招武器拖尾开始
	void SlashOneWeaponTrailStart (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = true;
			hitPoint.SetActive(true);//激活武器与敌人的碰撞点
			GetComponent<AudioSource>().PlayOneShot(swordHit1);
		}
	}
	//连招第一招武器拖尾结束
	void SlashOneWeaponTrailEnd (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = false;
			hitPoint.SetActive(false);//关闭武器与敌人的碰撞点
		}
	}
	//连招第二招武器拖尾开始
	void SlashTwoWeaponTrailStart (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = true;
			hitPoint.SetActive(true);//激活武器与敌人的碰撞点
			GetComponent<AudioSource>().PlayOneShot(swordHit2);
		}
	}
	//连招第二招武器拖尾结束
	void SlashTwoWeaponTrailEnd (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = false;
			hitPoint.SetActive(false);//关闭武器与敌人的碰撞点
		}
	}
	//连招第三招武器拖尾开始
	void SlashThreeWeaponTrailStart (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = true;
			hitPoint.SetActive(true);//激活武器与敌人的碰撞点
			GetComponent<AudioSource>().PlayOneShot (jiaoHanSheng);
		}
	}
	//连招第三招武器拖尾结束
	void SlashThreeWeaponTrailEnd (bool isShow) {
		if (isShow) {
			weaponTrail.Emit = false;
			hitPoint.SetActive(false);//关闭武器与敌人的碰撞点
		}
	}
	//第三连招特效产生
	void SlashThreeEffect (bool isShow) {
		if (isShow) {
			Instantiate(slashThreeEffectPrefab,slashThreePoint.transform.position,slashThreePoint.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot (earthHitMusic);
		}
	}
	//主角死亡时发出的声音，动画事件添加的声音
	void PlayerDeadSound (bool isDead) {
		if (isDead) {
			GetComponent<AudioSource>().PlayOneShot(playerDeadSound);
		}
	}
}
