using UnityEngine;
using System.Collections;

public class BossSkill : MonoBehaviour {

	public GameObject skill3;
	public GameObject skill3Point1;
	public AudioClip earthHit;

	public GameObject skill1;
	public GameObject skill1Point1;
	public GameObject skill1Point2;
	public GameObject skill1Point3;
	public GameObject skill1Point4;
	public GameObject skill1Point5;
	public GameObject skill1Point6;
	public GameObject skill1Point7;
	public GameObject skill1Point8;
	public GameObject skill1Point9;
	public GameObject skill1Point10;

	public GameObject bossSword;
	public GameObject hitPoint;
	private MeleeWeaponTrail bossSwordTrail;

	void Awake () {
		bossSwordTrail = bossSword.gameObject.GetComponent<MeleeWeaponTrail>();
	}

	void Skill1 (bool isTrue) {
		if (isTrue) {
			Instantiate(skill1,skill1Point6.transform.position,skill1Point6.transform.rotation);
			Instantiate(skill1,skill1Point7.transform.position,skill1Point7.transform.rotation);
			Instantiate(skill1,skill1Point8.transform.position,skill1Point8.transform.rotation);
			Instantiate(skill1,skill1Point9.transform.position,skill1Point9.transform.rotation);
			Instantiate(skill1,skill1Point10.transform.position,skill1Point10.transform.rotation);
			Instantiate(skill1,skill1Point1.transform.position,skill1Point1.transform.rotation);
			Instantiate(skill1,skill1Point2.transform.position,skill1Point2.transform.rotation);
			Instantiate(skill1,skill1Point3.transform.position,skill1Point3.transform.rotation);
			Instantiate(skill1,skill1Point4.transform.position,skill1Point4.transform.rotation);
			Instantiate(skill1,skill1Point5.transform.position,skill1Point5.transform.rotation);
			StartCoroutine (Skill1Wait());
		}
	}

	void Skill3 (bool isSkill) {
		if (isSkill) {
			Instantiate (skill3,skill3Point1.transform.position,skill3Point1.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(earthHit);
		}
	}

	void Skill2TrailStart (bool isTrue) {
		if (isTrue) {
			bossSwordTrail.Emit = true;
			hitPoint.SetActive (true);
		}
	}
	void Skill2TrailEnd (bool isTrue) {
		if (isTrue) {
			bossSwordTrail.Emit = false;
			hitPoint.SetActive (false);
		}
	}
	IEnumerator Skill1Wait () {
		yield return new WaitForSeconds(1);
		Instantiate(skill1,skill1Point1.transform.position,skill1Point1.transform.rotation);
		Instantiate(skill1,skill1Point2.transform.position,skill1Point2.transform.rotation);
		Instantiate(skill1,skill1Point3.transform.position,skill1Point3.transform.rotation);
		Instantiate(skill1,skill1Point4.transform.position,skill1Point4.transform.rotation);
		Instantiate(skill1,skill1Point5.transform.position,skill1Point5.transform.rotation);
		Instantiate(skill1,skill1Point6.transform.position,skill1Point6.transform.rotation);
		Instantiate(skill1,skill1Point7.transform.position,skill1Point7.transform.rotation);
		Instantiate(skill1,skill1Point8.transform.position,skill1Point8.transform.rotation);
		Instantiate(skill1,skill1Point9.transform.position,skill1Point9.transform.rotation);
		Instantiate(skill1,skill1Point10.transform.position,skill1Point10.transform.rotation);
	}
}
