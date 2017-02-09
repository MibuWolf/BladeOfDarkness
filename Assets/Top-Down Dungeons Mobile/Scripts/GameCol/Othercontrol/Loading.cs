using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	UISprite loadingUI;//loading进度条UI
	UILabel loadingLabel;//loading显示文本
	AsyncOperation async;//异步对象

	void Start () {
		loadingUI = GetComponent<UISprite>();
		loadingUI.fillAmount = 0;
		loadingLabel = GetComponentInChildren<UILabel>();
		StartCoroutine (LoadScene ());//开启一个异步任务，进入LoadScene方法
	}

	void Update () {
		loadingUI.fillAmount = async.progress;
		loadingLabel.text = string.Format("Loading {0}%",(int)(async.progress*100));
	}

	IEnumerator LoadScene () {
		async = Application.LoadLevelAsync(Global.GetInstance().loadName);//异步读取场景
		yield return async;//读取完毕后，系统自动进入读取的游戏场景
	}
}
