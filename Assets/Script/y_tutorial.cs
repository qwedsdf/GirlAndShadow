using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class y_tutorial : MonoBehaviour {
	public Image black;
	public AudioSource start_se;
	bool loadflg;
	float alpha;

	// Use this for initialization
	void Start () {
		black.color = new Color (0,0,0,0);
		black.enabled = false;
		loadflg = false;
		alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		feed ();
	}

	void feed(){
		if (loadflg) {
			alpha += 0.03f;
			black.color = new Color (0,0,0,alpha);
			if(alpha>1)SceneManager.LoadScene ("stage_1");
		}
	}

	public void next(){
		start_se.Play ();
		black.enabled = true;
		loadflg = true;
	}
}
