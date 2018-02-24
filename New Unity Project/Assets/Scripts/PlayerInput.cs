using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public int threshold;
	public Material mat;

	private Note[] notes;
	private int transpose = 0;

	private BitString	keys;
	private int numOfKeys=13;

	// Use this for initialization
	void Start () {
		keys = new BitString(numOfKeys);

		notes = new Note[numOfKeys];
		for(int i = 0; i < numOfKeys; ++i) {
			AudioSource temp = GameObject.Instantiate(this.transform.GetChild(0).transform.GetChild(0), this.transform.GetChild(0)).GetComponent<AudioSource>();
			temp.pitch = Mathf.Pow(2, (i+transpose)/12.0f);
			notes[i] = new Note(temp);
		}
	}

	// Update is called once per frame
	void Update () {
		changeKey();
		playChord();
	}

	void changeKey() {
		keys.set(0, Input.GetKey(KeyCode.Q));
		keys.set(1, Input.GetKey(KeyCode.W));
		keys.set(2, Input.GetKey(KeyCode.E));
		keys.set(3, Input.GetKey(KeyCode.R));
		keys.set(4, Input.GetKey(KeyCode.T));
		keys.set(5, Input.GetKey(KeyCode.Y));
		keys.set(6, Input.GetKey(KeyCode.U));
		keys.set(7, Input.GetKey(KeyCode.I));
		keys.set(8, Input.GetKey(KeyCode.O));
		keys.set(9, Input.GetKey(KeyCode.P));
		keys.set(10, Input.GetKey(KeyCode.LeftBracket));
		keys.set(11, Input.GetKey(KeyCode.RightBracket));
		keys.set(12, Input.GetKey(KeyCode.Backslash));
	}

	void playChord() {
		for(int i = 0; i < numOfKeys; ++i) {
			if(keys.at(i)==1)
				notes[i].play();
			else if (keys.at(i)==0)
				notes[i].stop(); //Note.stop does not actually stop the audio
		}
		/*
		//Naive implementation
		if(keys==new BitString("100")) {
			mat.color = Color.red;
		}
		else if(keys==new BitString("110")) {
			mat.color = Color.magenta;
		}
		else if(keys==new BitString("010")) {
			mat.color = Color.blue;
		}
		else if(keys==new BitString("011")) {
			mat.color = Color.cyan;
		}
		else if(keys==new BitString("001")) {
			mat.color = Color.green;
		}
		else if (keys==new BitString("101")) {
			mat.color = Color.yellow;
		}
		else if (keys==new BitString("111")) {
			mat.color = Color.black;
		}
		else {
			mat.color = Color.white;
		}
		*/
	}
}
