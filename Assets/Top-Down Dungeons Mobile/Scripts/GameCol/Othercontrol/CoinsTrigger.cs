using UnityEngine;
using System.Collections;

public class CoinsTrigger : MonoBehaviour {

	public AudioClip coinsSound;
	private CoinsNum cn;
	public int num;
	
	void Awake () {
		GameObject coinsNumUI = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Coins");
		cn = coinsNumUI.gameObject.GetComponent<CoinsNum>();
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.tag == "PlayerNinja") {
			//Destroy(this.gameObject);
			StartCoroutine(DestoryWaitTime ());
			cn.CoinsNumAdd (num);
			GetComponent<AudioSource>().PlayOneShot (coinsSound);
		}
	}

	IEnumerator DestoryWaitTime () {
		yield return new WaitForSeconds(0.3f);
		Destroy(this.gameObject);
	}
}
