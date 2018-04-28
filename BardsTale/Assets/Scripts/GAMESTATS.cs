using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioCollection : MonoBehaviour
{
    //holds all the chords
    public AudioSource I;
    public AudioSource i;
    public AudioSource IIb;
    public AudioSource iib;
    public AudioSource II;
    public AudioSource ii;
    public AudioSource IIIb;
    public AudioSource iiib;
    public AudioSource III;
    public AudioSource iii;
    public AudioSource IV;
    public AudioSource iv;
    public AudioSource Vb;
    public AudioSource vb;
    public AudioSource V;
    public AudioSource v;
    public AudioSource VIb;
    public AudioSource vib;
    public AudioSource VI;
    public AudioSource vi;
    public AudioSource VIIb;
    public AudioSource viib;
    public AudioSource VII;
    public AudioSource vii;

    public AudioSource[] clips;

    public void Start()
    {
        clips = new AudioSource[] { I, i, IIb, iib, II, ii, IIIb, iiib, III, iii, IV, iv, Vb, vb, V, v, VIb, vib, VI, vi, VIIb, viib, VII, vii };
    }
}

//CONTAINS EVERYTHING OUR OTHER SCRIPTS SHOULD USE TO MAKE DECISIONS
//CONTAINS EVERYTHING OUT OTHER SCRIPTS SHOULD CHANGE
public static class GAMESTATS   {
    public static bool isBattle = false;
    

    public static Vector2 barbLoc = new Vector2(-1.0f, -1.0f);
    public static Vector2 bardLoc = new Vector2(0.0f, 0.0f);

    public static float olk = 0.0f;
    public static float acy = 0.0f;
    public static float ass = 0.0f;

    public static float volume = 0.0f;
    public static float tempo = 0.0f;
    public static float frequency = 0.0f;
    public static float tension = 0.0f;
    public static float tone = 0.0f;


    public static int[,] tensions = new int[,]{{ 0,  0,  0,  0,  5,  4,  0,  0,  6,  1,  5,  1,  0,  0,  6,  2,  4,  0,  6,  3,  4,  2,  3,  0},
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
    public static int[] tones = new int[] {
        3, -1, -2, -2, 1, 2, -2, -1, -2, 2, 2, 1, -2, -1, 2, 1, -2, -2, 2, -3, 1, -2, 1, 1 };
    public static string[] possChords = new string[] { "I", "i", "IIb", "iib", "II", "ii", "IIIb", "iiib", "III", "iii", "IV", "iv",
            "Vb", "vb", "V", "v", "VIb", "vib", "VI", "vi", "VIIb", "viib", "VII", "vii"};
    public static int[] chosenChords = new int[] {
        0, 10, 14, 19, 9, 20 }; //initializes the chosenChords (hotkeys) to default values

    public static string[] battlefeels = new string[] { "Determined", "Curious", "Defeated", "Terrified", "Victorious", "Cautious", "Relenting", "Alert" };
    public static string[] normalfeels = new string[] { "Determination", "Foreboding", "Hopeless", "Nervous", "Elated", "Excited", "Content", "Hopeful" };
    public static bool inBattle = false;
}
