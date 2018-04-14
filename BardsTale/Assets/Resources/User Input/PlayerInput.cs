using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {


	private Chord[] chords;
	public AudioClip[] notes;
	private int[] hotkeyMapping;

	private bool[] keys;
	private int numOfKeys=8; //Number of keys to press
	private int numOfChords=24; //Number of unique chords

	// Currently has to specifically set the dropdowns as values in this array
	// To automate later
	public Dropdown[] profile;

	// Use this for initialization
	void Start () {
		keys = new bool[numOfKeys];
		chords = new Chord[numOfChords];
		//notes = new AudioSource[numOfTones];
		hotkeyMapping = new int[numOfKeys];

		//Sets bottom half of chords to major triads, upper half to minor
		/*
		for(int i = 0; i < numOfChords/2; i++) {
			chords[2*i] = new Chord(notes[i]);
			chords[2*i+1] = new Chord(notes[i]);
		}
		*/

		for(int i = 0; i<numOfChords; ++i) {
			AudioSource x = gameObject.AddComponent<AudioSource>();
			x.clip = notes[i];
			chords[i] = new Chord(x);
		}



		loadChords();
		//Only for testing
	}

	// Update is called once per frame
	void Update () {
		changeKey();
		updateHotbar(); //Currently inefficient
		saveChords();
	}

	// Takes input from 1-8 on keyboard
	// Maybe add numpad option/remapping later
	void changeKey() {
		bool[] keys1 = new bool[numOfKeys];
		keys1[0]= Input.GetKeyDown(KeyCode.Alpha1);
		keys1[1]= Input.GetKeyDown(KeyCode.Alpha2);
		keys1[2]= Input.GetKeyDown(KeyCode.Alpha3);
		keys1[3]= Input.GetKeyDown(KeyCode.Alpha4);
		keys1[4]= Input.GetKeyDown(KeyCode.Alpha5);
		keys1[5]= Input.GetKeyDown(KeyCode.Alpha6);
		keys1[6]= Input.GetKeyDown(KeyCode.Alpha7);
		keys1[7]= Input.GetKeyDown(KeyCode.Alpha8);

		bool changed = false;
		for(int i = 0; i<numOfKeys; i++) {
			if(keys1[i]) {
				changed = true;
				break;
			}
		}

		if(changed) {
			keys=keys1;
			playChord();
		}
	}

	//Plays chords based on what's selected
	void playChord() {
		for(int i = 0; i < numOfKeys; ++i) {
			if(keys[i])
				chords[hotkeyMapping[i]].play();
			else
				chords[hotkeyMapping[i]].stop(); //Note.stop does not actually stop the audio
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
