using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_ghost_sc : MonoBehaviour {
	public float spd;

	void OnEnable (){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector3 pos = transform.position;
		pos.x += spd;
		transform.position = pos;
	} 
}
