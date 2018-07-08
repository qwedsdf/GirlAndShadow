using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class y_stage_move : MonoBehaviour {

	[SerializeField, Range(0, 10)]
	//何秒後に到達するか
	float time = 1;
	public GameObject Player_obj;
	private Vector3    endPosition;

	//どこのポジションに移動するか
	private GameObject EndGameObject;

	private float startTime;
	private Vector3 startPosition;

	//カメラのポジション
	public Camera maincamera;

	void OnEnable ()
	{
		Vector3 StartObjectPos = GameObject.Find ("stage_" + (Player.stagecount - 1).ToString ()).transform.position;
		transform.position = StartObjectPos + new Vector3 (0.0f,0.0f,5f);
		if(Player.stagecount == 5)Player_obj.transform.rotation = Quaternion.Euler (0,270,0);
		EndGameObject = GameObject.Find ("stage_"+ Player.stagecount.ToString());
		endPosition = EndGameObject.transform.position;
		endPosition += new Vector3 (0,0,transform.position.z);

		if (time <= 0) {
			transform.position = endPosition;
			enabled = false;
			return;
		}

		startTime = Time.timeSinceLevelLoad;
		startPosition = transform.position;
	}

	void FixedUpdate ()
	{
		Vector3 p_pos=Player_obj.transform.position;
		maincamera.transform.position = new Vector3 (p_pos.x,p_pos.y,-10f);
		var diff = Time.timeSinceLevelLoad - startTime;
		if (diff > time) {
			transform.position = endPosition;
			enabled = false;
			SceneManager.LoadScene ("stage" + Player.stagecount.ToString());
		}

		var rate = diff / time;

		transform.position = Vector3.Lerp (startPosition, endPosition, rate);
	}

	//Sceneで線を可視化
	void OnDrawGizmosSelected ()
	{
		#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
		#endif
	}

}
