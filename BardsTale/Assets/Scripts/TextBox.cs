using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBox : MonoBehaviour {
	Text shownText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			Destroy(this);
		}
	}

	public void setMessage(string message) {
		this.GetComponentInChildren<Text>().text= message;
	}

	public void delete() {
		Destroy(this);
	}
}
