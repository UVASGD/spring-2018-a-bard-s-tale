using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord{

	AudioSource[] baseAudio;

	bool isPlaying;

	public Chord(AudioSource a, AudioSource b, AudioSource c) {
		baseAudio = new AudioSource[3];
		baseAudio[0] = a;
		baseAudio[1] = b;
		baseAudio[2] = c;
		isPlaying = false;
	}

	public void play() {
		if(!isPlaying) {
			isPlaying = true;
			foreach (AudioSource x in baseAudio) {
				x.Stop();
				x.Play();
			}
		}
	}

	public void stop() {
		isPlaying=false;
		foreach (AudioSource x in baseAudio)
			x.Stop();
	}
}
