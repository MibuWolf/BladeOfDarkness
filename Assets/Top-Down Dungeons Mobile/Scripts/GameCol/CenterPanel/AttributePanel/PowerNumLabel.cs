using UnityEngine;
using System.Collections;

public class PowerNumLabel : MonoBehaviour {

	UILabel powerNumLabel;
	private Transform player;
	private PlayerPower pp;

	void Awake () {
		powerNumLabel = GetComponent<UILabel>();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		pp = player.gameObject.GetComponent<PlayerPower>();
	}

	void Update () {
		powerNumLabel.text = string.Format("{0}",pp.playerPower);
	}
}
