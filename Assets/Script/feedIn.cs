using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feedIn : MonoBehaviour {
	float alpha;
	public float spd;
	public GameObject bt;

	// Use this for initialization
	void Start () {
		alpha = 0;
		bt.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		alpha+=Time.deltaTime*spd / 100;
		this.GetComponent<Image> ().color = new Color(255f,255f,255f,alpha);
	}
}
