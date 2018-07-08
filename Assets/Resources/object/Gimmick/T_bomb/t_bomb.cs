using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_bomb : MonoBehaviour {

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool camera = false;
    public float BombCount = 2;
    public GameObject ExploadObj;
    public GameObject ExploadPos;
    Quaternion rot;
    //float w, h;

    //float rot = this.GameObject.GetComponent<Transform>();
    //public GameObject Explosionrange;

    // Use this for initialization
    void Start ()
    {
        //h = 1;
        //w = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        rot = this.transform.rotation;
        float y = rot.eulerAngles.x;
        if (camera && y == 270 && BombCount > -3)
        {
            BombCount -= Time.deltaTime;
            //Debug.Log("カメラに入った");
        }

        if (BombCount <= 0)
        {
            //this.transform.localScale = new Vector3(w, 1, h);
            //w += 0.1f;
            //h += 0.02f;
            GetComponent<CapsuleCollider>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
            //Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);
            //Destroy(this.player);
            //Instantiate(Explosionrange, ExploadPos.transform.position, Quaternion.identity);
            //Debug.Log("爆発する");
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

    //void OnCollisionEnter(Collision coll)
    //{
    //    if (BombCount <= 0)
    //    {
    //        if (coll.gameObject.tag == "player_shadow")
    //        {
    //            Destroy(this.player);
    //        }
    //    }
    //}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
