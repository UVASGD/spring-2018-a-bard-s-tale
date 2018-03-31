using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoChange : MonoBehaviour {
	private Slider tempoSlider;
	public TempoToggle tempo;

	// Use this for initialization
	void Start () {
		tempo = GameObject.FindGameObjectWithTag ("ToggleT").GetComponent<> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
