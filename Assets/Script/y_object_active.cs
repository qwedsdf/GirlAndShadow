using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct obj_info{
	public GameObject obj;
	public float posX;
	public bool setflg;
	public bool death_flg;

	public void _setflg(bool flg){setflg = flg;}
	public void _death_flg(bool flg){death_flg = flg;}

}

public class y_object_active : MonoBehaviour {
	List<obj_info> game_obj = new List<obj_info>();
	public GameObject Player;


	// Use this for initialization
	void Start () {
		//リストにオブジェクトを入れて色を変える
		foreach (Transform child in transform)
		{
			obj_info unko = new obj_info ();
			unko.death_flg = false;
			unko.setflg = false;
			unko.obj = child.gameObject;
			unko.posX = unko.obj.transform.position.x;
			game_obj.Add (unko);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//オブジェクトが近づいたらアクティブにする
		for (int i = 0; i < game_obj.Count; i++) {
			if (game_obj [i].death_flg)continue;

			else if (game_obj [i].setflg) {
				if (game_obj [i].posX - Player.transform.position.x < -5f) {
					game_obj [i].obj.SetActive (false);
					game_obj [i]._death_flg (false);
				}
			}
			else {
				if (game_obj [i].posX - Player.transform.position.x < 22f) {
					game_obj [i].obj.SetActive (true);
					game_obj [i]._setflg (false);
				}
			}
		}
	}
}
