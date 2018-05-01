using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personality : MonoBehaviour {

    public float oMod = 0.0f;
    public float gMod = 0.0f;
    public float aMod = 0.0f;

    public string attitude = "";

	// Use this for initialization
	void Start () { 
		
	}

	// Update is called once per frame
	void Update () {
        genAttitude();
    }

    void genAttitude()
    {
        float tone = GAMESTATS.tone;
        float tension = GAMESTATS.tension;
        float tempo = GAMESTATS.tempo;
        float frequency = GAMESTATS.frequency;
        float volume = GAMESTATS.volume;

        float olk = 0.0f;
        float acy = 0.0f;
        float ass = 0.0f;

        olk = (10 + (tempo / 120) + tone - tension) / 10 + oMod;
        ass = (15 - tension + tone) / 10 + aMod;
        acy = ((volume * 10) + (tempo / 120) + (frequency * 2)) / 10 + gMod;

        int index_z = (olk > 0) ? 1 : 0;
        int index_y = (acy > 0) ? 1 : 0;
        int index_x = (ass > 0) ? 1 : 0;

        attitude = "";
        if (GAMESTATS.isBattle)
        {
            attitude = GAMESTATS.battlefeels[index_z * 4 + index_y * 2 + index_x];
        }
        else
        {
            attitude = GAMESTATS.normalfeels[index_z * 4 + index_y * 2 + index_x];
        }
    }
}
