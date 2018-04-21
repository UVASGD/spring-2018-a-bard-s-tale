using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(new Vector3(-1f*speed,0f,0f)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(new Vector3(1f*speed,0f,0f)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			transform.Translate(new Vector3(0f,1f*speed,0f)*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			transform.Translate(new Vector3(0f,-1f*speed,0f)*Time.deltaTime);
		}
	}
}
