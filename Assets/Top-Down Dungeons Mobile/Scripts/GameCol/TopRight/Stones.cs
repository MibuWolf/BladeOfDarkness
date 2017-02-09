using UnityEngine;
using System.Collections;

public class Stones : MonoBehaviour {

	UILabel stonesNumLabel;
	public int stonesNum;

	void Awake () {
		stonesNumLabel = gameObject.GetComponentInChildren<UILabel>();
	}

	void Update () {
		stonesNumLabel.text = string.Format("X{0}",stonesNum);
	}

	public void StonesNumAdd (int num) {
		stonesNum += num;
	}
}
