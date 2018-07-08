using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_move_door : MonoBehaviour {
	public float spd;
	public float stop_pos;
	float first_pos;
	// Use this for initialization
	void Start () {
		first_pos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		move_door ();
	}

	void move_door(){
		if(Player.stop_flg)transform.position += new Vector3 (spd,0,0);
		if (transform.position.x - first_pos > stop_pos) {
//		Player.stop_flg = false;
//		Player.ani.SetBool ("stop_flg",false);
//		Player_kage.ani.SetBool ("stop_flg",false);
		enabled = false;
		}
	}
}
