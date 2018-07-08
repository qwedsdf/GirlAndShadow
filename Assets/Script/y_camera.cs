using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_camera : MonoBehaviour {
	public GameObject Player_camera;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Player_kage.goolflg||Player.death_flg)return;
		Vector3 pos = transform.position;
		pos.x = Player_camera.transform.position.x + 7.8f;
		transform.position = pos;
	}
}
