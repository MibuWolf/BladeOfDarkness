using UnityEngine;
using System.Collections;

public class HealthNumLabel : MonoBehaviour {

	UILabel healthNumLabel;//属性面板生命值文本
	private PlayerHealth ph;
	private Transform player;

	void Awake () {
		healthNumLabel = GetComponent<UILabel>();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		ph = player.gameObject.GetComponent<PlayerHealth>();
	}

	void Update () {
		healthNumLabel.text = string.Format("{0}",ph.playerHealth);
	}
}
