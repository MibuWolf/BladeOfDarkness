using UnityEngine;
using System.Collections;

public class EnemyBloodPanel : MonoBehaviour {

	public float offectX;
	public float offectY;
	public float offectZ;
	public GameObject enemyBloodPanelPrefab;

	private GameObject enemyBloodPanel;
	private float enemyHeight;

	void Awake () {
		enemyBloodPanel = Instantiate(enemyBloodPanelPrefab,transform.position,transform.rotation) as GameObject;
		enemyBloodPanel.transform.localScale = new Vector3(0.015f,0.015f,0.01f);
		enemyHeight = gameObject.GetComponent<Collider>().bounds.size.y;
	}
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(transform.position.x+offectX,transform.position.y+enemyHeight+offectY,transform.position.z+offectZ);
		enemyBloodPanel.transform.position = pos;
		enemyBloodPanel.transform.rotation = Camera.main.transform.rotation;
	}
}
