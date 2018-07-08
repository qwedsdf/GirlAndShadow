using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class y_feed_img : MonoBehaviour {
	Image img;
	float alpha;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		alpha -= 0.05f; 
		img.color = new Color (0f,0f,0f,alpha);
		if (alpha < 0)
			Destroy (this.gameObject);
	}
}
