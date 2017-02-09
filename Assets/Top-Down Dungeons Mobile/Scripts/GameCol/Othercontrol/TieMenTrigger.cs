using UnityEngine;
using System.Collections;

public class TieMenTrigger : MonoBehaviour {

	public GameObject target;
	private KeyNum kn;//钥匙数量脚本
	public GameObject newsPanel1;//提示消息框1
	public GameObject newsPanel2;//提示消息框2
	private bool isShow;//提示消息框2是否显示

	void Awake () {
		GameObject keyNumUI = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Key");
		//GameObject newsPanel = GameObject.Find("UI Root/Camera/Anchor-TopRight/NewsPanel");
		kn = keyNumUI.gameObject.GetComponent<KeyNum>();
	}

	void Update () {
		if (isShow == true) {
			StartCoroutine(HideWaitTime ());
			isShow = false;
		}
	}
	//当主角进入触发器
	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerNinja") {
			if (kn.keyNum > 0) {
				target.GetComponent<Animation>().Play();
				kn.KeyNumAdd (-1);
			}
			if (kn.keyNum <= 0) {
				StartCoroutine (ShowWaitTime ());
			}
			newsPanel2.SetActive(false);
		}
	}
	//当主角离开触发器
	void OnTriggerExit (Collider other) {
		if (other.tag == "PlayerNinja") {
			newsPanel1.SetActive(false);
			newsPanel2.SetActive(true);
			isShow = true;
		}
	}
	//提示消息框等待显示
	IEnumerator ShowWaitTime () {
		yield return new WaitForSeconds (0.2f);
		newsPanel1.SetActive(true);
	}
	//提示消息框等待隐藏
	IEnumerator HideWaitTime () {
		yield return new WaitForSeconds (1.5f);
		newsPanel2.SetActive(false);
	}
}
