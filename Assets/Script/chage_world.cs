using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chage_world : MonoBehaviour {
	float save_pos;
	private float diffrence;
	GameObject player;
	float rote;

	// Use this for initialization
	void Start () {
		diffrence = 21.7f;
		save_pos = 22f;
		player = GameObject.Find ("player");
		rote = transform.rotation.x * 180f;

	}

	// Update is called once per frame
	void Update () {
		//回転
		if(Player.death_flg)return;
		float diffrence_pos = Mathf.Abs(transform.position.x - player.transform.position.x);
		float  renge = 180f;
		if (diffrence_pos < diffrence) {
			if (save_pos >= diffrence && Mastar.changeflg == 1) {
				if (rote == 0)
					rote -= 180;
				else
					rote = 0;
			}
			/*Debug.Log (rote);
			Debug.Log (renge);*/
			//　　　　　　　　　　　　　　　　　　　　　　0　　　　　　180　　　-180
			transform.rotation = Quaternion.Euler (Mastar.changeflg * renge + rote, 0f, 0f);
		}
		save_pos=diffrence_pos;
	}
}
