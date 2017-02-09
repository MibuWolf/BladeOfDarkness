using UnityEngine;
using System.Collections;

public class NumLabel : MonoBehaviour {

	UILabel numLabel;
	public int num;
	public int needCoinsNum;
	public int needStonesNum;

	void Awake () {
		numLabel = gameObject.GetComponent<UILabel>();
		num = 0;
		needCoinsNum = 0;
		needStonesNum = 0;
	}

	void Update () {
		numLabel.text = string.Format("{0}",num);
		if (num <= 0) {
			num = 0;
		}
		if (needCoinsNum <= 0) {
			needCoinsNum = 0;
		}
		if (needStonesNum <= 0) {
			needStonesNum = 0;
		}
	}
	//血瓶数量售卖界面上要买的数量变化
	public void NumAdd (int numChange) {
		num += numChange;
		needCoinsNum += numChange*50;
		needStonesNum += numChange*10;
	}
}
