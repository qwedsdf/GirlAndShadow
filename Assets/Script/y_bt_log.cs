using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_bt_log : MonoBehaviour {
	public GameObject End_Panel;
	// Use this for initialization
	void Start () {
		if (!y_object_all.once)
		{
			DontDestroyOnLoad(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (Application.platform == RuntimePlatform.Android)
//		{
			// エスケープキー取得
			if (Input.GetKey(KeyCode.Escape))
			{
				Time.timeScale = 0;
				End_Panel.SetActive (true);
			}
		//}
	}

	public void bt_yes(){
		// アプリケーション終了
		Application.Quit();
		return;
	}

	public void bt_no(){
		Time.timeScale = 1;
		End_Panel.SetActive (false);
	}
}
