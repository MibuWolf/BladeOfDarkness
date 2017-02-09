using UnityEngine;
using System.Collections;

public class GameAgain : MonoBehaviour {

	public GameObject uiRoot;
	public GameObject playerNinja;
	public GameObject playerCamera;
	public GameObject playerJoystick;
	public GameObject boss;
	public GameObject transPoint1;
	public GameObject transPoint2;
	public GameObject salseMan;

	void OnClick () {
		Application.LoadLevel ("Menu");
		Destroy (uiRoot);
		Destroy (playerNinja);
		Destroy (playerCamera);
		Destroy (playerJoystick);
		Destroy (boss);
		Destroy (transPoint1);
		Destroy (transPoint2);
		Destroy (salseMan);
	}
}
