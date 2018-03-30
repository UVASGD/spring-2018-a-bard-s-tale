using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bard : MonoBehaviour {

	// Use this for initialization
	private Chord[] chordArr;
	private int[] hotkeys;
	private int prevChord;
	private float timeDiff;
	//private Ally[] allyArr;
	private float[] musicQualities;
	/*
	0 = tempo
	1 = freq
	2 = vol
	3 = tension
	4 = tone
	*/
	private int[,] tensionArr;
	private int[] toneArr;

	int hotkeySize = 8;
	int numOfChords = 24;
	int numOfAllies = 0;

	public AudioClip[] notes; //Temp solution

	Event e;

	void Start () {
			/***** initialization of fields *****/
			chordArr = new Chord[numOfChords];
			hotkeys = new int[hotkeySize];
			prevChord = 0;
			timeDiff = 0;
			//allyArr = Ally[n]; Need ally class first
			musicQualities = new float[5];
			//I'm putting these at the bottom since tension will be large.
			setTension();
			setTone();

			/***** setting chords in chordArr *****/
			//Need .wav files
			//Might just do this manually in scene(?)
			for(int i = 0; i<numOfChords; ++i) {
				AudioSource x = gameObject.AddComponent<AudioSource>();;
				x.clip = notes[i];
				chordArr[i] = gameObject.AddComponent<Chord>();
				chordArr[i].setAudio(x);
			}

	}

	// Update is called once per frame
	void Update () {
		e = Event.current;
		if (e.type == EventType.KeyDown)
		{
				/** Handles all button presses! **/
				int key = (int)e.keyCode - (int)KeyCode.Alpha1;
				if (key >= 0 && key < hotkeySize)	{
						playChord(key);
						prevChord = hotkeys[key];
				}
		}

		for(int i = 0; i < numOfChords; ++i) {
			if(i != prevChord) {
				chordArr[i].stop();
			}
		}
		timeDiff += Time.deltaTime;
	}

	void playChord(int num) { //the number of the button pressed is passed in
		int chord = hotkeys[num];
		chordArr[chord].play();
		//tensionArr[chord][prevChord]
		//toneArr[chord]
		prevChord = chord;
		timeDiff = 0;
	}

	void affectAllies() {

	}

	void changeHotkeys(int[] newKeys) {
		hotkeys = newKeys;
	}

	void changeVol(int v) {

	}

	void changeTempo(int t) {

	}

	void getTensionMod() {

	}

	void getToneMod() {

	}

	void setTension() {
		tensionArr = new int[,] { {0, 0, 0, 0, 5, 4, 0, 0, 6, 1, 5, 1},
									{-1, 0, 0, 0, 0, 0, 3, 0, 0, 0, -3, 3},
									{-1, -3, 0, 1, 0, 0, 1, 0, 0, 0, 0, -2},
									{-1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 2},
									{-2, 0, 0, -3, 0, 2, 0, 0, 1, 1, -2, 0},
									{-5, 2, 0, 0, 1, 0, 0, 0, 4, 2, 3, 5},
									{-1, -3, 2, 0, 0, 0, 0, 1, 0, 1, 2, 2},
									{-2, 0, 1, 1, 0, 0, -2, 0, 0, 0, 0, 0},
									{-3, 0, 0, -1, 0, -2, 0, 0, 0, -2, 4, 0},
									{-2, 0, 0, 1, 3, 2, 2, 0, 3, 0, 4, 2},
									{-7, -2, 0, 0, 1, -3, -4, 1, 1, -4, 0, 2},
									{-3, -3, 2, 0, 0, 2, -3, 0, 1, -2, -1, 0}};
	}

	void setTone() {

		toneArr = new int[] {3, -1, -2, -2, 1, 2, -2, -1, -2, 2, 2, 1, -2, -1, 2, 1, -2, -2, 2, -3, 1, -2, 1, 1};

	}
}
