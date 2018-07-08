using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_kage : MonoBehaviour {
	public GameObject _parent;
	public GameObject death_effct;
	public GameObject feed;
	public GameObject Camera;
	public GameObject bt_pouse;
	public AudioSource kick_se;
	public AudioSource death_se;
	public float run_spd;
	static public Animator ani;
	static public bool goolflg;

	// Use this for initialization
	void Start () {
		bt_pouse.SetActive (true);
		goolflg = false;
		ani = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (feed.GetComponent<Image> ().color.a > 0.9) {
			if(Player.stagecount == 5)SceneManager.LoadScene ("y_movie");
			else SceneManager.LoadScene ("y_proloog");
		}
		if (Player.death_flg)Death ();
	}

	void FixedUpdate () {
		move ();
	}

	//移動
	void move(){
		if (Player.death_flg || Mastar.pouse_flg||Player.stop_flg)return;
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 moveDirection=Vector3.zero;
		moveDirection.x += run_spd * Time.deltaTime;
		controller.Move(moveDirection);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "kick_col") {
			ani.SetTrigger ("kick_trig");
			kick_se.Play ();
		}
		if (col.tag == "camera_stop"||col.tag=="stop") {
			goolflg = true;
		}

		//ゴールに着いた
		if (col.tag == "gool") {
			feed.SetActive (true);
			bt_pouse.SetActive (false);
			if (Player.stagecount == 5) {
				Player.stop_flg = true;
			}
		}

		//最終ステージでドアの前に来た時
		if(col.tag == "stop"){
			ani.SetBool ("stop_flg",true);
			feed.SetActive (true);
			bt_pouse.SetActive (false);
			if (Player.stagecount == 5) {
				Player.stop_flg = true;
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		//ゲームオーバーの判定
		if (hit.gameObject.CompareTag("jump_obj") || hit.gameObject.CompareTag("toge_first") || hit.gameObject.CompareTag("kaidan")) {
			Death ();
		}
	}

	void Death(){
		//if (!Player.death_flg)
		death_se.Play ();
		Player.death_flg = true;
		//Camera.transform.parent = null;
		//Instantiate (death_effct,transform.position,Quaternion.identity);
		//Destroy (this.gameObject);
	}

}
