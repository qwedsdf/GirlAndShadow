using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_open_door : MonoBehaviour {
	public GameObject door;
	public GameObject switch_obj;
	public AudioSource botton_se;
	public Sprite on_switch;
	public Sprite off_switch;
	float first_position;
	bool pushflg;

	// Use this for initialization
	void Start () {
		first_position = door.transform.position.y;
		pushflg = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (!pushflg) {
			if(door.transform.position.y>first_position)door.transform.position += new Vector3 (0,-0.1f,0);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "button") {
			door.transform.position += new Vector3 (0,0.1f,0);
			if(!pushflg){
				switch_obj.GetComponent<SpriteRenderer> ().sprite = on_switch;
				pushflg = true;
				botton_se.Play ();
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "button") {
			pushflg = false;
			switch_obj.GetComponent<SpriteRenderer> ().sprite = off_switch;
		}
	}
}
