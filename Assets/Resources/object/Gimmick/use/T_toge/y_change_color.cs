using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class y_change_color : MonoBehaviour {
	
	Color color_1;　//最初の色
	Color set_color;
	public Color color_2;　//変える色
	GameObject look_parent;

	// Use this for initialization
	void Start () {
		color_1 = GetComponent<MeshRenderer> ().material.color;
		look_parent = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
 	}
	
	// Update is called once per frame
	void Update () {
		

		if (look_parent.transform.rotation.x != 0) {
			if (set_color == color_2)return;
				set_color = color_2;	
		}
		else {
			if (set_color == color_1)return;
			set_color = color_1;
		}

			GetComponent<MeshRenderer> ().material.color = set_color;
	}
}
