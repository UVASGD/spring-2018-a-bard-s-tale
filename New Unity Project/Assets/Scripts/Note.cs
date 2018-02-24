using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note{

	AudioSource baseAudio;
	bool isPlaying;

	public Note(AudioSource a) {
		baseAudio = a;
		isPlaying = false;
	}

	public void play() {
		if(!isPlaying) {
			isPlaying = true;
			baseAudio.Stop();
			baseAudio.Play();
		}
	}

	public void stop() {
		isPlaying=false;
		baseAudio.Stop();
	}
}
