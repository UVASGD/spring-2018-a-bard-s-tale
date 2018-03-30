using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GVarHandler : MonoBehaviour {

    public AudioSource speaker;

    // Keybindings data
    public Image AOn;
    public Image SOn;
    public Image DOn;
    public Image FOn;
    public Image GOn;
    public Image HOn;

    public Text AVal;
    public Text SVal;
    public Text DVal;
    public Text FVal;
    public Text GVal;
    public Text HVal;

    //Sliders data
    public Toggle battletime;
    public Slider TSlide;
    public Slider VSlide;

    //Bottom row data
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

    //private data for algorithm-ing
    private string[] chords;
    private int prevChord = -1;
    private string[] possChords;
    private int[,] tensions;
    private int[] tones;

    private string[] normalfeels;
    private string[] battlefeels;

    //globals for calculations
    private float frequency;
    private int tension;
    private int tone;
    private float tempo;
    private float volume;

    private int cooldown = 0;
    private float lastTime = 0.001f;

    private float acy = 0.0f;
    private float olk = 0.0f;
    private float ass = 0.0f;

    // Use this for initialization
    private void Start() {
        tone = 0;
        tension = 5;
        frequency = 0.0f;

        //value is between 0 and 1
        //expect max speed to be 240 bpm
        tempo = TSlide.value * 240;

        //value is between 0 and 1
        volume = VSlide.value;

        setChords();
        setPossChords();
        setTones();
        setTensions();

        setFeels();
	}

    // initialization but compressed, for algorithm-y stuff
    void setChords()
    {
        chords = new string[6];
        AVal.text = "I";
        chords[0] = "I";
        SVal.text = "IV";
        chords[1] = "IV";
        DVal.text = "V";
        chords[2] = "V";
        FVal.text = "vi";
        chords[3] = "vi";
        GVal.text = "iii";
        chords[4] = "iii";
        HVal.text = "ii";
        chords[5] = "ii";
    }

    void setPossChords()
    {
        possChords = new string[] { "I", "i", "IIb", "iib", "II", "ii", "IIIb", "iiib", "III", "iii", "IV", "iv",
            "Vb", "vb", "V", "v", "VIb", "vib", "VI", "vi", "VIIb", "viib", "VII", "vii"};
    }

    void setTones()
    {
        tones = new int[] { 3, -1, -2, -2, 1, 2, -2, -1, -2, 2, 2, 1, -2, -1, 2, 1, -2, -2, 2, -3, 1, -2, 1, 1};
    }

    void setTensions()
    {
        tensions = new int[,]{{ 0,  0,  0,  0,  5,  4,  0,  0,  6,  1,  5,  1,  0,  0,  6,  2,  4,  0,  6,  3,  4,  2,  3,  0},
                                   {-1,  0,  0,  0,  0,  0,  3,  0,  0,  0, -3,  3,  0,  0,  0,  2,  4,  2,  0,  0,  0,  0,  0,  0},
                                   {-1, -3,  0,  1,  0,  0,  1,  0,  0,  0,  0, -2,  2,  1,  0,  2,  1,  0, -2,  0,  1,  0,  0,  2},
                                   {-1,  0,  0,  0,  0,  0,  0,  1,  3,  0,  0,  2, -2, -1,  0,  0,  3,  1, -4,  0,  0,  0,  2,  1},
                                   {-2,  0,  0, -3,  0,  2,  0,  0,  1,  1, -2,  0,  0,  2,  4,  0,  0,  0,  2, -3,  0,  0,  2,  4},
                                   {-5,  2,  0,  0,  1,  0,  0,  0,  4,  2,  3,  5,  0,  0,  5,  0,  0,  0, -2, -5,  3,  4,  0,  0},
                                   {-1, -3,  2,  0,  0,  0,  0,  1,  0,  1,  2,  2,  1,  0,  3, -3, -3, -3,  0,  0,  2,  1, -2, -3},
                                   {-2,  0,  1,  1,  0,  0, -2,  0,  0,  0,  0,  0, -2, -1,  0, -2, -2, -2,  0,  0,  0, -3, -3, -3},
                                   {-3,  0,  0, -1,  0, -2,  0,  0,  0, -2,  4,  0,  0,  1,  2,  0,  0, -2,  0, -8,  0,  0,  0, -1},
                                   {-2,  0,  0,  1,  3,  2,  2,  0,  3,  0,  4,  2,  3,  1,  4, -3,  2,  1,  3, -3,  0,  0,  2,  2},
                                   {-7, -2,  0,  0,  1, -3, -4,  1,  1, -4,  0,  2,  0,  0,  5, -2,  2,  0,  1, -4,  2,  0,  0,  0},
                                   {-3, -3,  2,  0,  0,  2, -3,  0,  1, -2, -1,  0,  0,  0,  1,  2, -4, -2,  0,  0,  2,  1,  0,  1},
                                   {-1,  0,  0, -2,  1,  0, -3,  1,  0,  0, -1,  0,  0,  1,  0,  1, -2, -2, -2,  0,  0, -2,  3,  2},
                                   {-1,  0,  0, -2,  1,  0, -1,  0,  0,  0,  0, -3, -2,  0,  0,  1,  1,  0, -2, -1, -1, -1,  2,  2},
                                   {-8, -3,  0,  0,  1, -4,  3,  0,  2, -2, -1, -1,  0,  0,  0,  2,  1,  0,  2, -5,  1,  0,  2, -2},
                                   {-5, -2, -2,  0,  3,  2, -1,  1,  4, -2, -4, -3,  0,  1,  1,  0,  3,  1,  2,  1, -4, -3,  0,  0},
                                   {-1, -4,  1, -3,  2,  2, -2, -3,  1,  0, -1,  0, -3, -1,  3, -2,  0, -2,  0, -2,  1, -1,  0,  0},
                                   {-1, -2,  0, -2,  0,  2, -2, -1,  2, -3,  0,  2, -1, -2,  0, -2, -1,  0,  0,  0, -2,  1,  0,  0},
                                   {-5,  0,  2,  1,  2, -2,  0,  0,  1, -3, -3,  0,  3,  1,  2,  0,  0,  0,  0, -1,  0,  0,  0, -1},
                                   {-1,  2,  0,  0,  4,  1,  0,  0,  5,  3,  4,  3,  0,  0,  5,  4,  2,  1,  4,  0,  2,  4,  0,  2},
                                   {-8,  0,  0,  0, -3, -3, -4,  2,  3,  0, -5, -2,  0, -1,  0,  2, -2, -2,  0, -3,  0, -1,  0,  0},
                                   {-2,  0,  0,  0,  0,  0, -1, -1,  4,  0, -2, -3, -1, -2,  0,  1, -2, -2,  0, -1, -3,  0,  0,  0},
                                   {-5,  0,  0, -2, -2,  0,  0, -3,  2, -3,  0,  0,  1,  0,  2,  0,  2,  3,  0, -3,  0, -1,  0,  1},
                                   {-1,  0,  0,  0, -4,  0,  0,  0,  0, -2,  0, -2,  0,  2,  4,  0,  1,  0, -2, -4,  0,  0,  1,  0}};
    }

    void setFeels()
    {
        normalfeels = new string[] { "Determination", "Foreboding", "Hopeless", "Nervous", "Elated", "Excited", "Content", "Hopeful"};
        battlefeels = new string[] { "Determined", "Curious", "Defeated", "Terrified", "Victorious", "Cautious", "Relenting", "Alert" };
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
        else
        {
            cooldown = 20;
            int index = 0;
            if (Input.GetKey(KeyCode.A))
            {
                AOn.color = Color.green;
                string chordPlayed = AVal.text;
                //find index, for the val given
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }

                //set tone
                tone += tones[index];
                Ton.text = "" + tone;

                //set tension
                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                }
                Ten.text = "" + tension;

                //set freq
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;


                //set LPC
                LPC.text = AVal.text;
                prevChord = index;
            }
            else
            {
                AOn.color = Color.red;
            }
            if (Input.GetKey(KeyCode.S))
            {
                SOn.color = Color.green;
                string chordPlayed = SVal.text;
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }
                tone += tones[index];
                Ton.text = "" + tone;

                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                }
                Ten.text = "" + tension;
                
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;

                LPC.text = SVal.text;
                prevChord = index;
            }
            else
            {
                SOn.color = Color.red;
            }
            if (Input.GetKey(KeyCode.D))
            {
                DOn.color = Color.green;
                string chordPlayed = DVal.text;
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }
                tone += tones[index];
                Ton.text = "" + tone;

                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                }
                Ten.text = "" + tension;

                //set freq
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;

                LPC.text = DVal.text;
                prevChord = index;
            }
            else
            {
                DOn.color = Color.red;
            }
            if (Input.GetKey(KeyCode.F))
            {
                FOn.color = Color.green;
                string chordPlayed = FVal.text;
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }
                tone += tones[index];
                Ton.text = "" + tone;

                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                }
                Ten.text = "" + tension;

                //set freq
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;

                LPC.text = FVal.text;
                prevChord = index;
            }
            else
            {
                FOn.color = Color.red;
            }
            if (Input.GetKey(KeyCode.G))
            {
                GOn.color = Color.green;
                string chordPlayed = GVal.text;
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }
                tone += tones[index];
                Ton.text = "" + tone;

                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                }
                Ten.text = "" + tension;

                //set freq
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;

                LPC.text = GVal.text;
                prevChord = index;
            }
            else
            {
                GOn.color = Color.red;
            }
            if (Input.GetKey(KeyCode.H))
            {
                HOn.color = Color.green;
                string chordPlayed = HVal.text;
                for (int i = 0; i < possChords.Length; i++)
                {
                    if (chordPlayed.Equals(possChords[i]))
                    {
                        index = i;
                        break;
                    }
                }
                tone += tones[index];
                Ton.text = "" + tone;

                if (prevChord == -1)
                {
                    tension = tensions[0, index];
                }
                else
                {
                    tension = tensions[prevChord, index];
                    if (tension < 0)
                        tension = 0;
                }
                Ten.text = "" + tension;

                //set freq
                float deltTime = Time.time - lastTime;
                lastTime = Time.time;
                frequency = deltTime / tempo;
                Freq.text = "" + frequency;

                LPC.text = HVal.text;
                prevChord = index;
            }
            else
            {
                HOn.color = Color.red;
            }
        }
        calcFunctions();
        getAttitude();

        tempo = TSlide.value * 240;
        Tempo.text = "" + tempo;
        volume = VSlide.value;
        Volume.text = "" + volume;
    }

    void calcFunctions()
    {
        // By the time we reach this function, we have a value for tempo, frequency, tension, tone, and volume.
        olk = 10 + (tempo / 120) + tone - tension;
        ass = 15 - tension + tone;
        acy = (volume * 10) + (tempo / 120) + (frequency * 2);
        
        if (olk > 1)
        {
            olk = 1;
        }
        if (ass > 1)
        {
            ass = 1;
        }
        if (acy > 1)
        {
            acy = 1;
        }
        if (olk < -1)
        {
            olk = -1;
        }
        if (ass < -1)
        {
            ass = -1;
        }
        if (acy < -1)
        {
            acy = -1;
        }

        Agency.text = "" + acy;
        Outlook.text = "" + olk;
        Assurance.text = "" + ass;
    }

    void getAttitude()
    {
        int zaxis = 0;
        int yaxis = 0;
        int xaxis = 0;

        if (olk > 0)
        {
            zaxis = 1;
        }
        else
        {
            zaxis = 0;
        }
        if (acy > 0)
        {
            yaxis = 1;
        }
        else
        {
            yaxis = 0;
        }
        if (ass > 0)
        {
            xaxis = 1;
        }
        else
        {
            xaxis = 0;
        }


        if (battletime.isOn)
        {
            ATT.text = battlefeels[(zaxis * 4) + (yaxis * 2) + xaxis];
        }
        else
        {
            ATT.text = normalfeels[(zaxis * 4) + (yaxis * 2) + xaxis];
        }

    }
}
