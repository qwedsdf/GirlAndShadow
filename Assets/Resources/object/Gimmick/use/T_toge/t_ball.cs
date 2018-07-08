using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_ball : MonoBehaviour
{
	public AudioSource roll_over_se;
	GameObject _parent;
    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "player_shadow")
		{
			Debug.Log ("hit");
			roll_over_se.Play ();
			GetComponent<Rigidbody>().AddForce(new Vector3(2.0f, 0.0f, 0.0f).normalized * 500);
		}
	}

    void OnCollisionEnter(Collision coll)
    {
		//追加
		if (transform.parent == null)
			return;
			
        if (coll.gameObject.tag == "player_shadow" || coll.gameObject.tag == "toge_obj")
        {
			Debug.Log ("hit");
			if (coll.gameObject.tag == "player_shadow")roll_over_se.Play ();
            GetComponent<Rigidbody>().AddForce(new Vector3(2.0f, 0.0f, 0.0f).normalized * 500);
        }

		//////////////////ヨハ追加するで//////////////////////////
		GameObject _parent=transform.parent.gameObject.transform.parent.gameObject;

		//反転しないようにする
		if(coll.gameObject.tag == "toge_first"){
			_parent.GetComponent<chage_world> ().enabled = false;
		}

		//最後のトゲに当たったら画面外に出す
		if(coll.gameObject.tag == "toge_last"){
			float adjustment=1;
			if (transform.parent.gameObject.transform.parent.gameObject.transform.rotation.x != 0)
				adjustment = -1;
			GetComponent<Rigidbody>().AddForce(new Vector3(2.0f, 5.0f*adjustment, 0.0f).normalized * 500);
			transform.parent = null;
		}
		/////////////////////////////////////////
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
