using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personality : MonoBehaviour {
	public GVarHandler pScore;
	private double acy;
	private double olk;
	private double ass;



	public Personality() {
		this.acy = -.1;
		this.olk = -.1;
		this.ass = -.1;

	}

	public Personality barb = new Personality ();


	// Use this for initialization
	void Start () { 
		pScore = GameObject.FindObjectOfType (typeof(GVarHandler)) as GVarHandler;
		acy = barb.acy + float.Parse(pScore.Agency.text);
		olk = barb.olk + float.Parse(pScore.Outlook.text);
		ass = barb.ass + float.Parse(pScore.Assurance.text);

	}

	// Update is called once per frame
	void Update () {
		acy = barb.acy + float.Parse(pScore.Agency.text);
		olk = barb.olk + float.Parse(pScore.Outlook.text);
		ass = barb.ass + float.Parse(pScore.Assurance.text);
		pScore.getAttitude (acy, olk, ass);
	}


}
