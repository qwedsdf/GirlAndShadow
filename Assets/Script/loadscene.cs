using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour {
	public AudioSource tap_se;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void load(){
		tap_se.Play ();
		if (Player.stagecount == 5) {
			SceneManager.LoadScene ("y_movie");
			return;
		}
		SceneManager.LoadScene ("move_stage");
	}

	public void load_title(){
		tap_se.Play ();
		SceneManager.LoadScene ("title");
	}
}
