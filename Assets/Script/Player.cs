using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float jump_spd;
	public float jump_max;
	public float run_spd;
	float Total_time;
	static public Animator ani;
	public GameObject parent;
	public GameObject Player_shadow;
	public GameObject death_effct;
	public GameObject death_image;
	public GameObject retry;
	public GameObject title;
	public AudioSource landing;
	public AudioSource last;
	public AudioSource jump_se;
	public AudioSource hit_girl;
	bool once_flg;
	static public bool death_flg;
	static public bool stop_flg;
	static public int stagecount = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		Total_time = 0;
		stop_flg = false;
		ani = GetComponent<Animator> ();
		death_image.SetActive (false);
		retry.SetActive (false);
		title.SetActive (false);
		death_flg = false;
		once_flg = false;
		transform.position = new Vector3 (transform.position.x,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (death_flg)Death ();
	}
		
	void move(){
		if (Mastar.pouse_flg||stop_flg)return;
		//if (ani.GetCurrentAnimatorStateInfo (0).IsName ("run"))transform.position = new Vector3 (transform.position.x,0f,0f);
		CharacterController controller = GetComponent<CharacterController> ();
		Vector3 moveDirection = Vector3.zero;
		float run = run_spd;
		if (transform.position.x - Player_shadow.transform.position.x < 0)run += 2;
		moveDirection.x += run * Time.deltaTime;
		if(ani.GetCurrentAnimatorStateInfo(0).IsName("run"))moveDirection.y -= 9.8f * Time.deltaTime;
		controller.Move (moveDirection);
	}

	void OnTriggerEnter(Collider col){
		//ジャンプさせる
		if (col.tag == "jump_col") {
			jump_se.Play ();
			ani.SetBool ("jump",true);
		}
		//最終ステージでドアの前に来た時
		if(col.tag == "stop"){
			ani.SetBool ("stop_flg",true);
			stop_flg = true;
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		//ジャンプ後に着地
		if (ani.GetCurrentAnimatorStateInfo(0).IsName("Falling")&&hit.gameObject.tag == "yuka") {
			ani.SetTrigger ("landing");
			Total_time = 0;
			landing.Play ();
			ani.Play ("run",0,Player_kage.ani.GetCurrentAnimatorStateInfo (0).normalizedTime);
		}
		//ゲームオーバーの判定
		if (hit.gameObject.tag == "kick_obj" || hit.gameObject.tag == "ball_obj" || /*hit.gameObject.tag == "jump_obj"||*/
			hit.gameObject.tag == "toge_obj" || hit.gameObject.tag == "enemy_obj") {
			if(run_spd!=0)hit_girl.Play();
			Death ();
			death_flg = true;
		}

		if(hit.gameObject.tag == "kaidan_last"){
			if (!once_flg) {
				last.Play ();
				once_flg = true;	
			}
		}
	}

	//死んだとき
	public void Death(){
		death_image.SetActive (true);
		retry.SetActive (true);
		title.SetActive (true);
		run_spd=0;
	}

	void FixedUpdate(){
		move ();

		Vector3 moveDirection = Vector3.zero;

		//ジャンプ中だったら
		if(ani.GetCurrentAnimatorStateInfo(0).IsName("jump")||ani.GetCurrentAnimatorStateInfo(0).IsName("Falling")){
			CharacterController controller = GetComponent<CharacterController> ();
			Total_time += Time.deltaTime;
			moveDirection.y -= 0.98f * Total_time - jump_spd;
			if (jump_spd < 0.98f * Total_time) {
				ani.SetBool ("jump",false);
			}
			controller.Move (moveDirection);
		}
	}
}
