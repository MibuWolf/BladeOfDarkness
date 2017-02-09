using UnityEngine;
using System.Collections;

public class CoinsNum : MonoBehaviour {

	UILabel coinsNumLabel;
	public int coinsNum;

	void Awake () {
		coinsNumLabel = gameObject.GetComponentInChildren<UILabel>();
	}

	void Update () {
		coinsNumLabel.text = string.Format("X{0}",coinsNum);
	}

	public void CoinsNumAdd (int num) {
		coinsNum += num;
	}
}
