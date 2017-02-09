using UnityEngine;
using System.Collections;

public class KeyNum : MonoBehaviour {

	UILabel keyNumLabel;
	public int keyNum;

	void Awake () {
		PlayerPrefs.SetInt("keyNum",keyNum);
		keyNumLabel = gameObject.GetComponentInChildren<UILabel>();
	}

	void Update () {
		PlayerPrefs.GetInt("keyNum",keyNum);
		keyNumLabel.text = string.Format("X{0}",keyNum);
		if (keyNum <= 0) {
			keyNum = 0;
		}
	}

	public void KeyNumAdd (int num) {
		keyNum += num;
	}
}
