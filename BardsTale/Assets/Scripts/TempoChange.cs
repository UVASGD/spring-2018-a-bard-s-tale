using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoChange : MonoBehaviour {
	private Slider tempoSlider;
	public TempoToggle tempo;

	// Use this for initialization
	void Start () {
		tempoSlider = GameObject.FindGameObjectWithTag ("TempoSlider").GetComponent<Slider> ();
		tempo = GameObject.FindGameObjectWithTag ("ToggleT").GetComponent<TempoToggle> ();
	}
	
	// Update is called once per frame
	void Update () {
		tempo.setTempo (tempoSlider.value);
	}
}
