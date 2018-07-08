using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_toge : MonoBehaviour
{
	public AudioSource se;

    // Use this for initialization
    void Start()
    {
		

    }

    // Update is called once per frame
    void Update()
    {
		
    }
		
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ball_obj")
        {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
			se.Play ();
			//ヨハ変更//
			float powwer_y=-1.0f;
			if (transform.parent.gameObject.transform.parent.gameObject.transform.rotation.x > -1)
				powwer_y = 1.0f;
			
			GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, powwer_y, 1.3f).normalized * 1000);

			GetComponent<BoxCollider> ().enabled = false;
			transform.parent = null;//親子関係を解除

        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
