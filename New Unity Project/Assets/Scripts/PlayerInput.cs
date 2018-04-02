using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {


	private Chord[] chords;
	private AudioSource[] notes;
	private int[] hotkeyMapping;
	private int transpose = 0;

	private bool[] keys;
	private int numOfKeys=8; //Number of keys to press
	private int numOfTones=20; //Number of semitones to calculate
	private int numOfChords=24; //Number of unique chords

	// Currently has to specifically set the dropdowns as values in this array
	// To automate later
	public Dropdown[] profile;

	// Use this for initialization
	void Start () {
		keys = new bool[numOfKeys];
		chords = new Chord[numOfChords];
		notes = new AudioSource[numOfTones];
		hotkeyMapping = new int[numOfKeys];
		for(int i = 0; i < numOfTones; ++i) {
			AudioSource temp = GameObject.Instantiate(this.transform.GetChild(0), this.transform).GetComponent<AudioSource>();
			temp.pitch = Mathf.Pow(2, (i+transpose)/12.0f);
			notes[i] = temp;
			loadChords();
		}

		//Sets bottom half of chords to major triads, upper half to minor
		for(int i = 0; i < numOfChords/2; ++i) {
			chords[i] = new Chord(notes[i], notes[i+4], notes[i+7]);
			chords[numOfChords/2+i]= new Chord(notes[i], notes[i+3], notes[i+7]);
		}
		//Only for testing
	}

	// Update is called once per frame
	void Update () {
		changeKey();
		updateHotbar(); //Currently inefficient
		saveChords();
		playChord();
	}

	// Takes input from 1-8 on keyboard
	// Maybe add numpad option/remapping later
	void changeKey() {
		keys[0]= Input.GetKeyDown(KeyCode.Alpha1);
		keys[1]= Input.GetKeyDown(KeyCode.Alpha2);
		keys[2]= Input.GetKeyDown(KeyCode.Alpha3);
		keys[3]= Input.GetKeyDown(KeyCode.Alpha4);
		keys[4]= Input.GetKeyDown(KeyCode.Alpha5);
		keys[5]= Input.GetKeyDown(KeyCode.Alpha6);
		keys[6]= Input.GetKeyDown(KeyCode.Alpha7);
		keys[7]= Input.GetKeyDown(KeyCode.Alpha8);
	}

	//Plays chords based on what's selected
	void playChord() {
		for(int i = 0; i < numOfKeys; ++i) {
			if(keys[i])
				chords[hotkeyMapping[i]].play();
				/*
			else if (keys.at(i)==0)
				chords[i].stop(); //Note.stop does not actually stop the audio
				*/

		}
	}

	//Goes through the dropdowns and updates values. Efficiency is currently questionable
	void updateHotbar() {
		for(int i = 0; i < numOfKeys; ++i) {
			hotkeyMapping[i]=profile[i].value;
		}
	}

	void saveChords() {
		for(int i = 0; i < numOfKeys; ++i) {
			PlayerPrefs.SetInt("Chord"+i, hotkeyMapping[i]);
		}
	}

	void loadChords() {
		for(int i = 0; i < numOfKeys; ++i) {
			hotkeyMapping[i] = PlayerPrefs.GetInt("Chord"+i);
			profile[i].value = hotkeyMapping[i];
		}
	}
}
