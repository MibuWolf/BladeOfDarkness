using UnityEngine;
using System.Collections;

public class BeginButton : MonoBehaviour {

	void Awake () {

	}
	void OnClick () {
		Global.GetInstance ().loadName = "Scene1";
		Application.LoadLevel ("Loading");
	}
}
