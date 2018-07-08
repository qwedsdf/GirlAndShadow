using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_enemy_come : MonoBehaviour {

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool camera = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(camera)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-0.1f, 0.0f, 0.0f).normalized * 1);
            GameObject parent;
            parent = transform.root.gameObject;
            //parent.GetComponent<chage_world>().enabled = false;
        }
    }

    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけcameraを有効に
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            camera = true;
        }
    }

        void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "player_shadow")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, -1.0f, 1.3f).normalized * 1000);
            GameObject parent;
            parent = transform.root.gameObject;
            parent.GetComponent<chage_world>().enabled = false;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
