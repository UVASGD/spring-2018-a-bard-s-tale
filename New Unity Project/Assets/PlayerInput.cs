using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public int threshold;
	public Material mat;
	private bool[]	keys;

	// Use this for initialization
	void Start () {
		keys = new bool[3];
	}

	// Update is called once per frame
	void Update () {
		changeKey();
		playChord();
	}

	void changeKey() {
		keys[0] = Input.GetKey(KeyCode.Alpha1);
		keys[1] = Input.GetKey(KeyCode.Alpha2);
		keys[2] = Input.GetKey(KeyCode.Alpha3);
	}

	void playChord() {
		//Naive implementation
		if(keys[0]&&!keys[1]&&!keys[2]) {
			mat.color = Color.red;
		}
		else if(keys[0]&&keys[1]&&!keys[2]) {
			mat.color = Color.magenta;
		}
		else if(!keys[0]&&keys[1]&&!keys[2]) {
			mat.color = Color.blue;
		}
		else if(!keys[0]&&keys[1]&&keys[2]) {
			mat.color = Color.cyan;
		}
		else if(!keys[0]&&!keys[1]&&keys[2]) {
			mat.color = Color.green;
		}
		else if (keys[0]&&!keys[1]&&keys[2]) {
			mat.color = Color.yellow;
		}
		else if (keys[0]&&keys[1]&&keys[2]) {
			mat.color = Color.black;
		}
		else {
			mat.color = Color.white;
		}
	}
}
