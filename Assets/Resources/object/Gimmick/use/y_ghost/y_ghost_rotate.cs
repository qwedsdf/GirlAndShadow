using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_ghost_rotate : MonoBehaviour {
	GameObject _parent;
	float rote_y;
	public AudioSource voice;

	void OnEnable(){
		
	}

	// Use this for initialization
	void Start () {
		_parent = transform.parent.gameObject.transform.parent.gameObject;
		rote_y = transform.localRotation.y*180;
		voice.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		change_rotate ();
		//if (transform.parent.gameObject.transform.position.y < 0.4)voice.Stop ();
	}

	void change_rotate(){
		
		float rote=rote_y;
		if (_parent.transform.rotation.x == 0) {
			rote -= 60;
		}
		transform.localRotation = Quaternion.Euler (0f, rote, 0f);
	}
}
