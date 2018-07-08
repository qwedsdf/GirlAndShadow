using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_soul_fead : MonoBehaviour {
	float alpha;
	GameObject soul;
	Color mate;
	//public bool up;
	// Use this for initialization
	void Start () {
		soul = transform.Find ("soul").gameObject;
		mate = soul.GetComponent<MeshRenderer> ().material.color;
		alpha = -1;
	}
	
	// Update is called once per frame
	void Update () {
		//人魂をだす
		if(transform.parent == null)return;
		float roteX = transform.parent.rotation.x;
		if (roteX != 0) {
			if (alpha == 1)return;
			alpha = 1;
		}
		else {
			if (alpha == 0)return;
			alpha = 0;
		}
	
		soul.GetComponent<MeshRenderer> ().material.color = new Color (mate.r, mate.g, mate.b, alpha);
	}
}
