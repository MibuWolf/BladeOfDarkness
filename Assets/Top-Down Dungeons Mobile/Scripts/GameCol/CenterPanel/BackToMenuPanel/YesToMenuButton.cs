using UnityEngine;
using System.Collections;

public class YesToMenuButton : MonoBehaviour {

	void OnClick () {
		//Global.GetInstance ().loadName = "Menu";
		Application.LoadLevel ("Menu");
		Time.timeScale = 1;
	}
}
