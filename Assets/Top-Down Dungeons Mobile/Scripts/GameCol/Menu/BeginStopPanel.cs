using UnityEngine;
using System.Collections;

public class BeginStopPanel : MonoBehaviour {

	private BoxCollider boxCol;//屏幕渐变遮挡面板碰撞框
	UIPanel beginStopPanel;
	private float changeSpeed;//屏幕渐变速度

	void Start () {
		boxCol = GetComponent<BoxCollider>();
		beginStopPanel = GetComponent<UIPanel>();
		beginStopPanel.alpha = 1;
		boxCol.enabled = true;
		changeSpeed = 0.1f;
	}

	void Update () {
		if (beginStopPanel.alpha > 0) {
			beginStopPanel.alpha -= Time.deltaTime * changeSpeed;
			boxCol.enabled = true;
		}
		if (beginStopPanel.alpha <= 0) {
			beginStopPanel.alpha = 0;
			boxCol.enabled = false;
		}
		if (changeSpeed > 0) {
			changeSpeed += 0.01f;
		}
		if (changeSpeed >= 0.7f) {
			changeSpeed = 0.7f;
		}
	}
}
