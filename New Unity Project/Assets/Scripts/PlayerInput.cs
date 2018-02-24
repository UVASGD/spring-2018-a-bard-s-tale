using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public int threshold;
	public Material mat;

	private Chord[] chords;
	private AudioSource[] notes;
	private int transpose = 0;

	private BitString	keys;
	private int numOfKeys=20;
	private int numOfChords=24;

	// Use this for initialization
	void Start () {
		keys = new BitString(numOfKeys);
		chords = new Chord[numOfChords];
		notes = new AudioSource[numOfKeys];
		for(int i = 0; i < numOfKeys; ++i) {
			AudioSource temp = GameObject.Instantiate(this.transform.GetChild(0).transform.GetChild(0), this.transform.GetChild(0)).GetComponent<AudioSource>();
			temp.pitch = Mathf.Pow(2, (i+transpose)/12.0f);
			notes[i] = temp;
		}

		for(int i = 0; i < 12; ++i) {
			chords[i] = new Chord(notes[i], notes[i+4], notes[i+7]);
			chords[12+i]= new Chord(notes[i], notes[i+3], notes[i+7]);
		}
	}

	// Update is called once per frame
	void Update () {
		changeKey();
		playChord();
	}

	void changeKey() {
		keys.set(0, Input.GetKey(KeyCode.Alpha1));
		keys.set(1, Input.GetKey(KeyCode.Alpha2));
		keys.set(2, Input.GetKey(KeyCode.Alpha3));
		keys.set(3, Input.GetKey(KeyCode.Alpha4));
		keys.set(4, Input.GetKey(KeyCode.Alpha5));
		keys.set(5, Input.GetKey(KeyCode.Alpha6));
		keys.set(6, Input.GetKey(KeyCode.Alpha7));
		keys.set(7, Input.GetKey(KeyCode.Alpha8));
	}

	void playChord() {
		for(int i = 0; i < 8; ++i) {
			if(keys.at(i)==1)
				chords[i].play();
			else if (keys.at(i)==0)
				chords[i].stop(); //Note.stop does not actually stop the audio
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
