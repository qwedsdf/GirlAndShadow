using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class y_cheak_fps : MonoBehaviour {
	public Text text1;

	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float fps = 1f / Time.deltaTime;
		text1.text = fps.ToString("f0");
	}
}
