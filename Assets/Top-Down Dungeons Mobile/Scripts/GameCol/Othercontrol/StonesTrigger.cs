using UnityEngine;
using System.Collections;

public class StonesTrigger : MonoBehaviour {

	public GameObject stonesEffect;
	private Stones st;
	public int num;

	void Awake () {
		GameObject stonesNumUI = GameObject.Find("UI Root/Camera/Anchor-TopRight/Panel/Stones");
		st = stonesNumUI.gameObject.GetComponent<Stones>();
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "PlayerNinja") {
			Destroy(this.gameObject);
			Instantiate(stonesEffect,transform.position,transform.rotation);
			st.StonesNumAdd(num);
		}
	}
}
