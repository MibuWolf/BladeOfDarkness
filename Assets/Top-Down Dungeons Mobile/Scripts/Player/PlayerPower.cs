using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour {

	public float playerPower;//玩家能量值
	public float realPower;//玩家真实能量值
	public float powerPercent;//初始能量值百分比
	public float replySpeed;//回复速度

	void Update () {
		if (realPower <= 0) {
			realPower = 0;
		}
		if (realPower < 100) {
			realPower += replySpeed*Time.deltaTime;;
		}
		if (realPower >= 100) {
			realPower = 100;
		}
		powerPercent = (int)realPower/playerPower;
	}
	//能量变化
	public void TakePower (float amount) {
		realPower += amount;
	}
}
