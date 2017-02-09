using UnityEngine;
using System.Collections;

public class SaleNumPanelCloseButton : MonoBehaviour {

	public GameObject salseNumPanel;

	void OnClick () {
		salseNumPanel.SetActive (false);
	}
}
