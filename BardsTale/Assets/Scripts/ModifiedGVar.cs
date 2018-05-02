using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifiedGVar : MonoBehaviour {

    // Keybindings data
    public Canvas ui;
    //Hotbar-related fields
    private Image[] onArray;
    private Text[] valArray;
    private GameObject hotbar;
    private bool hidden;

    //Slider fields
    public Slider TSlide;
    public Slider VSlide;
    //Momentum Bar
    public Image momentumBar;

    //Health fields
    private AudioCollector Audio;
    private int prevChord = -1;

    // miscellaneous Gvar Adaptation fields
    public bool debug_mode = false;
    #region debug_fields
    public Text LPC;

        public Text Freq;
        public Text Ten;
        public Text Ton;

        public Text Tempo;
        public Text Volume;

        public Text Outlook;
        public Text Agency;
        public Text Assurance;

        public Text ATT;
    #endregion

    public bool text_debug = false;

    //some more fields brought over from GVar
    #region properties
    private float frequency;
    private float tension;
    private float tone;
    private float tempo;
    private float volume;

    private int cooldown = 50;
    private int coolValue = 5;
    private bool isPlaying = false;
    private int stopcooldown = 30;
    private int stopcoolvalue = 60;
    private float lastTime = 0.001f;
    #endregion

    // Use this for initialization
    void Start () {
		initSlides(); //set sliders and momentum bar
		initHotbar();

        Audio = GetComponent<AudioCollector>();
	}

	// Update is called once per frame
	void Update () {
		//updateHotbar();//Changes sprites to red or green accordingly
        //The following are just for testing
        if (debug_mode)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                changeMomentum(.1f);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                changeMomentum(-.1f);
            }
            
        }

        if (isPlaying)
        {
            stopcooldown--;
        }
        cooldown--;
        if (cooldown > 0)
        {
            if (debug_mode)
            {
                //Debug.Log(cooldown + "");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playChord(onArray[0], GAMESTATS.possChords[GAMESTATS.chosenChords[0]], GAMESTATS.chosenChords[0]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[0]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[0].color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                playChord(onArray[1], GAMESTATS.possChords[GAMESTATS.chosenChords[1]], GAMESTATS.chosenChords[1]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[1]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[1].color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playChord(onArray[2], GAMESTATS.possChords[GAMESTATS.chosenChords[2]], GAMESTATS.chosenChords[2]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[2]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[2].color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                playChord(onArray[3], GAMESTATS.possChords[GAMESTATS.chosenChords[3]], GAMESTATS.chosenChords[3]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[3]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[3].color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                playChord(onArray[4], GAMESTATS.possChords[GAMESTATS.chosenChords[4]], GAMESTATS.chosenChords[4]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[4]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[4].color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                playChord(onArray[5], GAMESTATS.possChords[GAMESTATS.chosenChords[5]], GAMESTATS.chosenChords[5]);
                cooldown = coolValue;
                stopcooldown = stopcoolvalue;
            }
            else
            {
                if (stopcooldown < 0)
                    Audio.clips[GAMESTATS.chosenChords[5]].Stop();
                else
                    stopcooldown--;
                if (debug_mode)
                    onArray[5].color = Color.red;
            }
        }

        GAMESTATS.volume = volume;

        for (int i = 0; i < 24; ++i)
        {
            Audio.clips[i].volume = GAMESTATS.volume;
        }

        tempo = TSlide.value * 240;
        GAMESTATS.tempo = tempo;
        volume = VSlide.value;
        GAMESTATS.volume = volume;
        if (debug_mode)
        {
            Tempo.text = "" + tempo;
            Volume.text = "" + volume;
        }

    }

	//Initialization methods
	private void initHotbar() {
		hidden=false;
		hotbar = ui.transform.Find("Hotbar").gameObject;
		GameObject[] hotkeys = new GameObject[6];
		hotkeys[0] = hotbar.transform.Find("A").gameObject;
		hotkeys[1] = hotbar.transform.Find("S").gameObject;
		hotkeys[2] = hotbar.transform.Find("D").gameObject;
		hotkeys[3] = hotbar.transform.Find("F").gameObject;
		hotkeys[4] = hotbar.transform.Find("G").gameObject;
		hotkeys[5] = hotbar.transform.Find("H").gameObject;

		onArray = new Image[6];
		valArray = new Text[6];

		for(int i = 0; i< 6; i++) {
			onArray[i]=hotkeys[i].GetComponentInChildren<Image>();
			valArray[i]=hotkeys[i].GetComponentInChildren<Text>();
            valArray[i].text = GAMESTATS.possChords[GAMESTATS.chosenChords[i]];
		}

	}
    

	private void initSlides() {
        if (GAMESTATS.isBattle)
        {
            momentumBar.fillAmount = 0.5f;
        }
		
		TSlide = ui.transform.Find("Tempo/Tempo Slider").gameObject.GetComponent<Slider>();
		VSlide = ui.transform.Find("Volume/Volume Slider").gameObject.GetComponent<Slider>();
	}

    // update methods
    private void playChord(Image on, string text, int index)
    {
        if (debug_mode)
            on.color = Color.green;

        string chordPlayed = text;

        //set tone
        tone += (GAMESTATS.tones[index]);
        if (tone > 10)
        {
            tone = 10;
        }
        else if (tone < -10)
        {
            tone = -10;
        }
        GAMESTATS.tone = tone;
        if (debug_mode)
            Ton.text = "" + tone;

        //set tension
        if (prevChord == -1)
        {
            tension = tension + GAMESTATS.tensions[0, index];
        }
        else
        {
            tension = tension + GAMESTATS.tensions[prevChord, index];
        }
        if (tension < 0)
            tension = 0;
        if (tension > 20)
            tension = 20;
        if (debug_mode)
            Ten.text = "" + tension;
        GAMESTATS.tension = tension;

        //set freq
        float deltTime = Time.time - lastTime;
        lastTime = Time.time;
        frequency = (tempo - 240 * deltTime) / (tempo);
        if (frequency < 0)
            frequency = 0;
        if (debug_mode)
            Freq.text = "" + frequency;
        GAMESTATS.frequency = frequency;

        //set LPC
        if (debug_mode)
            LPC.text = text;
        prevChord = index;
        Audio.clips[index].Play();
    }

    private void updateHotbar() {
		//Hotbar is pressed down
		if(Input.GetKeyDown(KeyCode.A)) {
			onArray[0].color = Color.green;
            Debug.Log("A pressed");
            playChord(onArray[0], GAMESTATS.possChords[GAMESTATS.chosenChords[0]], GAMESTATS.chosenChords[0]);
		}
		if(Input.GetKeyDown(KeyCode.S)) {
			onArray[1].color = Color.green;
            Debug.Log("S pressed");
            playChord(onArray[1], GAMESTATS.possChords[GAMESTATS.chosenChords[1]], GAMESTATS.chosenChords[0]);
        }
		if(Input.GetKeyDown(KeyCode.D)) {
			onArray[2].color = Color.green;
            Debug.Log("D pressed");
            playChord(onArray[2], GAMESTATS.possChords[GAMESTATS.chosenChords[2]], GAMESTATS.chosenChords[0]);
        }
		if(Input.GetKeyDown(KeyCode.F)) {
			onArray[3].color = Color.green;
            Debug.Log("F pressed");
            playChord(onArray[3], GAMESTATS.possChords[GAMESTATS.chosenChords[3]], GAMESTATS.chosenChords[0]);
        }
		if(Input.GetKeyDown(KeyCode.G)) {
			onArray[4].color = Color.green;
            Debug.Log("G pressed");
            playChord(onArray[4], GAMESTATS.possChords[GAMESTATS.chosenChords[4]], GAMESTATS.chosenChords[0]);
        }
		if(Input.GetKeyDown(KeyCode.H)) {
			onArray[5].color = Color.green;
            Debug.Log("H pressed");
            playChord(onArray[5], GAMESTATS.possChords[GAMESTATS.chosenChords[5]], GAMESTATS.chosenChords[0]);
        }

		//Hotbar is released
		if(Input.GetKeyUp(KeyCode.A)) {
			onArray[0].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[0]].Stop();
		}
		if(Input.GetKeyUp(KeyCode.S)) {
			onArray[1].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[1]].Stop();
        }
		if(Input.GetKeyUp(KeyCode.D)) {
			onArray[2].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[2]].Stop();
        }
		if(Input.GetKeyUp(KeyCode.F)) {
			onArray[3].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[3]].Stop();
        }
		if(Input.GetKeyUp(KeyCode.G)) {
			onArray[4].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[4]].Stop();
        }
		if(Input.GetKeyUp(KeyCode.H)) {
			onArray[5].color = Color.red;
            Audio.clips[GAMESTATS.chosenChords[5]].Stop();
        }
		//Use tab to hide the hotbar!
		if(Input.GetKeyDown(KeyCode.Tab)) {
			if(!hidden) {
				hotbar.transform.Translate(new Vector3(0f,0f,1500f));
				hidden = !hidden;
			}
			else {
				hotbar.transform.Translate(new Vector3(0f,0f,-1500f));
				hidden = !hidden;
			}
		}
	}


    //Public methods which the Bard class can Use
    public void changeNote(int i, string s)
    {
        valArray[i].text = s;
    }

	public void setMomentum(float x) {
		momentumBar.fillAmount = x;
	}

	public void changeMomentum(float x) {
		momentumBar.fillAmount +=x;
	}

	public float getTempo() {
		return TSlide.value;
	}

	public float getVolume() {
		return VSlide.value;
	}
}
