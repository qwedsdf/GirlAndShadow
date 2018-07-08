using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kick_obj : MonoBehaviour {
	bool flg;
	// Use this for initialization
	void Start () {
		flg = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "player_shadow"&&!flg) {
			flg = true;
			GameObject _parent = transform.parent.gameObject;
			GetComponent<Rigidbody> ().AddForce (new Vector3(1.0f,-1.0f,1.3f).normalized*1000);
			if(_parent!=null)transform.parent.gameObject.GetComponent<chage_world> ().enabled = false;
			transform.parent = null;
		}
	}

	/*void OnTriggerEnter(Collider coll){
		if (coll.tag == "player_shadow") {
			if (transform.parent.gameObject == null)return;
			GameObject _parent = transform.parent.gameObject;
			GetComponent<Rigidbody> ().AddForce (new Vector3(1.0f,-1.0f,1.3f).normalized*1000);
			if(_parent!=null)transform.parent.gameObject.GetComponent<chage_world> ().enabled = false;
			transform.parent = null;

		}
	}*/

}

