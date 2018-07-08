using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_SetAspect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetAspect ();
	}

	void SetAspect(){
		Camera cam = GameObject.Find("Main Camera").GetComponent<Camera> ();

		// 理想の画面の比率
		float targetRatio = 16f / 9f;	
		// 現在の画面の比率
		float currentRatio = Screen.width * 1f / Screen.height;
		// 理想と現在の比率
		float ratio = currentRatio /  targetRatio;

		//カメラの描画開始位置をY座標にどのくらいずらすか
		float rectY = (1.0f - ratio) / 2f;
		//カメラの描画開始位置と表示領域の設定
		cam.rect = new Rect (0f, rectY, 1f, ratio);
		Debug.Log (targetRatio);
		Debug.Log (currentRatio);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
