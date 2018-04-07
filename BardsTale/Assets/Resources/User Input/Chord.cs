using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord{

	AudioSource baseAudio;
	//static float minDuration = 0.235f;

	public Chord(AudioSource x) {
		baseAudio = x;
	}
	public void play() {
			baseAudio.Stop();
			baseAudio.Play();
	}

	public void stop() {
		//if(baseAudio.time>minDuration)
				baseAudio.Stop();
	}

	public void setVolume(float f) {
		baseAudio.volume = f;
	}
}
