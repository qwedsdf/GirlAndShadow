using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class y_load : MonoBehaviour {
	AsyncOperation asy;
	// Use this for initialization
	void Start () {
		StartCoroutine(LoadScene());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator LoadScene(){
		asy=SceneManager.LoadSceneAsync("title");
		while (!asy.isDone) {
			yield return null;
		}
	}
}
