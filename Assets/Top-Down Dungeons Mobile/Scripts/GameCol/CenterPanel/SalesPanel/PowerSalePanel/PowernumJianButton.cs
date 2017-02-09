using UnityEngine;
using System.Collections;

public class PowernumJianButton : MonoBehaviour {

	private NumLabel numText;
	
	void Awake () {
		GameObject numLabel = GameObject.Find ("UI Root/Camera/Anchor-Center/PowerSaleNumPanel/NumSprite/Label");
		numText = numLabel.gameObject.GetComponent<NumLabel>();
	}
	
	void OnClick () {
		numText.NumAdd(-1);
	}
}
