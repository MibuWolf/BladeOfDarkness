using UnityEngine;
using System.Collections;

public class SalesManTrigger : MonoBehaviour {

	public GameObject salsePanel;//商品窗口
	public GameObject bloodSalePanel;//血瓶售卖窗口
	public GameObject powerSalePanel;//能量瓶售卖窗口
	public GameObject keySalePanel;//钥匙售卖窗口
	public GameObject newsPanel;//提示消息框
	public AudioClip salesManSound;//商人声音

	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerNinja") {
			salsePanel.SetActive (true);
			GetComponent<AudioSource>().PlayOneShot (salesManSound);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "PlayerNinja") {
			salsePanel.SetActive (false);
			bloodSalePanel.SetActive (false);
			powerSalePanel.SetActive (false);
			keySalePanel.SetActive (false);
			newsPanel.SetActive (false);
			GetComponent<AudioSource>().Stop();
		}
	}
}
