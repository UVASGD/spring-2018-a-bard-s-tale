using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolumeListener : MonoBehaviour {

	void Start()
	{
		AudioListener.volume = 0;
	}

	public void ChangeVolume(float newValue) {
		AudioListener.volume = newValue;
	}
}
