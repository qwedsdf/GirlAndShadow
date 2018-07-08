using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
	float alpha;
	public Image feed_img;
	AsyncOperation asy;
	public AudioSource bt_se;
	bool flg;
	bool once_flg;

	// Use this for initialization
	void Start () {
		alpha = 0;
		flg = false;
		once_flg = false;
		Player.stagecount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(PlayerPrefs.GetInt("Data"));
		feed();
	}

	void feed(){
		if (flg) {
			alpha += 0.03f;
			if (alpha > 1.5) {
				flg = false;
				StartCoroutine (LoadScene ());
			}
			feed_img.color = new Color(0f,0f,0f,alpha);
		}
	}

	public void loadscean(){
		flg = true;
		if (!once_flg) {
			bt_se.Play ();
			once_flg = true;
		}
	}
		
	IEnumerator LoadScene(){
		asy=SceneManager.LoadSceneAsync("y_proloog");
		while (!asy.isDone) {
			yield return null;
		}
	}
}
