using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_object_all : MonoBehaviour {
	public GameObject[] gameObjectArray;
	public AudioSource[] AudioArray;
	static public bool once=false;

	// Use this for initialization
	void Start () {
		Player.stagecount = 1;
		if (!once)
		{
			DontDestroyOnLoad(this);
			once = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
