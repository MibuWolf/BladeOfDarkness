using UnityEngine;
using System.Collections;

public class KeyTrigger : MonoBehaviour {

	private KeyNum kn;

	void Awake () {
		GameObject keyNumUI = GameObject.Find ("UI Root/Camera/Anchor-TopRight/Panel/Key");
		kn = keyNumUI.gameObject.GetComponent<KeyNum>();
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "PlayerNinja") {
			Destroy(gameObject);
			kn.KeyNumAdd (1);
		}
	}
}
