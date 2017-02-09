using UnityEngine;
using System.Collections;

public class NextSceneTrigger : MonoBehaviour {

	public GameObject uiRoot;
	public GameObject playerNinja;
	public GameObject playerCamera;
	public GameObject playerJoystick;
	public GameObject boss;
	public GameObject transPoint1;
	public GameObject transPoint2;
	public GameObject salesMan;

	private Vector3 newPoint;
	private Vector3 bossNewPoint;
	private Vector3 saleNewPoint;

	void Awake () {
		newPoint = new Vector3(0,0,-11);
		bossNewPoint = new Vector3(0,0,25);
		saleNewPoint = new Vector3(-1,0,-6);
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerNinja") {
			//Global.GetInstance ().loadName = "Scene2";
			Application.LoadLevel ("Scene2");
			DontDestroyOnLoad (uiRoot);
			DontDestroyOnLoad (playerNinja);
			DontDestroyOnLoad (playerCamera);
			DontDestroyOnLoad (playerJoystick);
			DontDestroyOnLoad (boss);
			DontDestroyOnLoad (transPoint1);
			DontDestroyOnLoad (transPoint2);
			DontDestroyOnLoad (salesMan);
			playerNinja.transform.position = newPoint;
			boss.transform.position = bossNewPoint;
			salesMan.transform.position = saleNewPoint;
			//playerJoystick.SetActive(false);
		}
	}
}
