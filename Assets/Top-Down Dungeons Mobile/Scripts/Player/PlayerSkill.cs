using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {

	public GameObject skillOneEffectPrefab;//技能一特效
	public Transform skillOnePoint;//技能一释放点

	public GameObject skillOneDamagePrefab;//技能一带伤害特效
	public Transform point1;//伤害释放点
	public Transform point2;
	public Transform point3;
	public Transform point4;
	public Transform point5;
	public Transform point6;
	public Transform point7;
	public Transform point8;

	public GameObject skillTwoEffectPrefab;//技能二特效
	public Transform skillTwoPoint;//技能二释放点
	public GameObject skillTwoDamagePrefab;//技能二带伤害特效
	public GameObject skillTwoPoint1;//伤害释放点
	public GameObject skillTwoPoint2;
	public GameObject skillTwoPoint3;
	public GameObject skillTwoPoint4;
	public GameObject skillTwoPoint5;
	public GameObject skillTwoPoint6;

	public GameObject skillThreeEffectPrefab;//技能三带伤害特效
	public Transform skillThreePoint1;//释放点
	public Transform skillThreePoint2;
	public Transform skillThreePoint3;
	public Transform skillThreePoint4;
	public Transform skillThreePoint5;

	public AudioClip skillOneMusic1;//技能一音效1
	public AudioClip skillOneMusic2;//技能一音效2
	public AudioClip playerSkillOneSound;//主角释放技能一时发出的声音
	public AudioClip skillTwoMusic;//技能二音效
	public AudioClip skillThreeMusic;//技能三音效

	public GameObject skill1Button;
	public GameObject skill2Button;
	public GameObject skill3Button;
	private SkillCD skill1CD;
	private SkillCD skill2CD;
	private SkillCD skill3CD;

	void Awake () {
//		skill1Button = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill1");
//		skill2Button = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill2");
//		skill3Button = GameObject.Find("UI Root/Camera/Anchor-BottomRight/Panel/Skill3");
		skill1CD = skill1Button.gameObject.GetComponent<SkillCD>();
		skill2CD = skill2Button.gameObject.GetComponent<SkillCD>();
		skill3CD = skill3Button.gameObject.GetComponent<SkillCD>();
	}

	//技能一
	void SkillOne (bool skillOne) {
		if (skillOne) {
			Instantiate (skillOneEffectPrefab,skillOnePoint.transform.position,skillOnePoint.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot (skillOneMusic1);
			StartCoroutine(SkillOne ());
			skill1CD.Click(true);
		}
	}
	//释放技能一时主角发出的声音
	void SkillOneSound (bool isSound) {
		if (isSound) {
			GetComponent<AudioSource>().PlayOneShot (playerSkillOneSound);
		}
	}
	//技能二
	void SkillTwo (bool skillTwo) {
		if (skillTwo) {
			Instantiate(skillTwoEffectPrefab,skillTwoPoint.transform.position,skillTwoPoint.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot (skillTwoMusic);
			StartCoroutine(SkillTwo ());
			skill2CD.Click (true);
		}
	}
	//技能三
	void SkillThree (bool skillThree) {
		if (skillThree) {
			Instantiate(skillThreeEffectPrefab,skillThreePoint1.transform.position,skillThreePoint1.transform.rotation);
			Instantiate(skillThreeEffectPrefab,skillThreePoint2.transform.position,skillThreePoint2.transform.rotation);
			Instantiate(skillThreeEffectPrefab,skillThreePoint3.transform.position,skillThreePoint3.transform.rotation);
			Instantiate(skillThreeEffectPrefab,skillThreePoint4.transform.position,skillThreePoint4.transform.rotation);
			Instantiate(skillThreeEffectPrefab,skillThreePoint5.transform.position,skillThreePoint5.transform.rotation);
			skill3CD.Click (true);
		}
	}
    //技能一延迟释放
	IEnumerator SkillOne () {
		yield return new WaitForSeconds(1.5f);
		GetComponent<AudioSource>().PlayOneShot(skillOneMusic2);
		Instantiate(skillOneDamagePrefab,point1.transform.position,point1.transform.rotation);
		Instantiate(skillOneDamagePrefab,point2.transform.position,point2.transform.rotation);
		Instantiate(skillOneDamagePrefab,point3.transform.position,point3.transform.rotation);
		Instantiate(skillOneDamagePrefab,point4.transform.position,point4.transform.rotation);
		Instantiate(skillOneDamagePrefab,point5.transform.position,point5.transform.rotation);
		Instantiate(skillOneDamagePrefab,point6.transform.position,point6.transform.rotation);
		Instantiate(skillOneDamagePrefab,point7.transform.position,point7.transform.rotation);
		Instantiate(skillOneDamagePrefab,point8.transform.position,point8.transform.rotation);
	}
	//技能二延迟释放
	IEnumerator SkillTwo () {
		yield return new WaitForSeconds(1.5f);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint1.transform.position,skillTwoPoint1.transform.rotation);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint2.transform.position,skillTwoPoint2.transform.rotation);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint3.transform.position,skillTwoPoint3.transform.rotation);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint4.transform.position,skillTwoPoint4.transform.rotation);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint5.transform.position,skillTwoPoint5.transform.rotation);
		Instantiate(skillTwoDamagePrefab,skillTwoPoint6.transform.position,skillTwoPoint6.transform.rotation);
	}
}
