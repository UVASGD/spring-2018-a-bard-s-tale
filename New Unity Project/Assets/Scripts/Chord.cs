using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord : MonoBehaviour{

	AudioSource baseAudio;
	static float minDuration = 0.235f;

	public void setAudio(AudioSource x) {
		baseAudio = x;
	}
	public void play() {
			baseAudio.Stop();
			baseAudio.Play();
	}

	public void stop() {
		if(baseAudio.time>minDuration)
				baseAudio.Stop();
	}

	void Start() {

	}

	void Update() {

	}
}
