using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class y_touka : MonoBehaviour {
	//いくつ階層が上の親か
	public int parent_num;
	float alpha;
	List<GameObject> child_obj = new List<GameObject>();
	List<Color> mate = new List<Color>();
	GameObject _parent;

	// Use this for initialization
	void Start () {
		//リストにオブジェクトを入れて色を変える
		foreach (Transform child in transform)
		{
			alpha = -1;
			child_obj.Add (child.gameObject);
			mate.Add (child.GetComponent<MeshRenderer> ().material.color);
		}

		_parent = transform.parent.gameObject;
		for (int i = 1; i < parent_num; i++) {
			_parent = _parent.transform.parent.gameObject;
		}
		/*char_1 = transform.Find ("Box021").gameObject;
		char_2 = transform.Find ("Box022").gameObject;*/
	}
	
	// Update is called once per frame
	void Update () {
		//オブジェクトを透過
		float roteX = _parent.transform.rotation.x;
		//Debug.Log (roteX);
		if (roteX != 0) {
			alpha = 0; 
		}
		else {
			alpha = 1;
		}
		
		for (int i = 0; i < child_obj.Count; i++) {
			child_obj[i].GetComponent<MeshRenderer> ().material.color = new Color (mate[i].r, mate[i].g, mate[i].b, alpha);
		}
	}
}