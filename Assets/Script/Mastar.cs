using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mastar : MonoBehaviour {
	static public float changeflg;
	Vector3 Acceleration;
	Vector3 preAcceleration;
	float DotProduct;
	public GameObject pouse_obj;
	public GameObject load_img;
	public AudioSource switching;
	public AudioSource pose;
	public AudioSource bt_pose;
	static public bool pouse_flg;

	// Use this for initialization
	void Start () {
		changeflg = 0;
		pouse_flg = false;
	}

	// Update is called once per frame
	void Update () {
		shack_cheack ();
	}

	void shack_cheack(){
		preAcceleration = Acceleration;
		Acceleration = Input.acceleration;
		DotProduct = Vector3.Dot(Acceleration, preAcceleration);
		if (DotProduct < 0)
			change ();
	}

	//ボタン入力
	//反転
	public void change(){
		switching.Play ();
		if (changeflg == 0)
			changeflg = 1;
		else
			changeflg = 0;
	}

	//リトライ
	public void retry(){
		SceneManager.LoadScene ("stage_" + Player.stagecount.ToString());
	}

	//ポーズ画面に移行(以下ポーズ画面時の処理)
	public void pouse(){
		Time.timeScale = 0;
		pouse_obj.SetActive (true);
		pouse_flg = true;
		pose.Play ();
	}

	//ゲームに戻る
	public void reture_game(){
		Time.timeScale = 1;
		pouse_obj.SetActive (false);
		pouse_flg = false;
		bt_pose.Play ();
	}

	//タイトルへ（諦める）
	public void give_up(){
		load_img.SetActive (true);
		bt_pose.Play ();
		SceneManager.LoadScene ("title");
	}

	//リスタート
	public void restart(){
		bt_pose.Play ();
		SceneManager.LoadScene ("stage_" + Player.stagecount.ToString ());
	}
}
