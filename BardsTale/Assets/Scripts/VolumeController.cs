using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {
	private Slider volumeSlider; 
	public VolumeListener vol;

	// Use this for initialization
	void Start() {
		vol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VolumeListener> ();
		volumeSlider = GameObject.FindGameObjectWithTag ("VolumeSlider").GetComponent<Slider>();
	}

	public void OnValueChanged() {
		vol.ChangeVolume (volumeSlider.value);
	}

	// Update is called once per frame
	void Update () {
		float newVol = volumeSlider.value;
		vol.ChangeVolume (newVol);
	}
}

