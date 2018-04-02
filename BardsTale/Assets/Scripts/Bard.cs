using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/* TODO: 
 * 1. Set up tone rules/matrix in getToneMod() and setToneMatrix() (however you want to do it)
 * 2. Have chords play in playChords()
 * 3. Set up chordArray
 * 4. Have Update() listen for:
 *      a. hotKeys and to play the right chord
 *      b. adjustments to the volume or tempo
 * 5. Make sure Start() initializes everything
 * 6. Change anything that you think should be changed
 */
public class Bard : MonoBehaviour
{
    //array of chords to play
    //most likely going to be strings of the sound filenames
    string[] chordArray;

    //array that stores the chords that will be played for each hotkey
    int[] hotKeys;

    //stores the index of the previous chord playes
    int prevChord;

    //the time difference between the current chord played and the last chord played
    float timeDiff;

    //list of allies that have joined your party
    Ally[] allies;

    //number of current allies you have
    int numAllies;

    //qualities of the music that you are playing
    //structure of array: [tempo, frequency, volume, tension, tone]
    float[] musicQualities;

    //matrix of modifications of tension
    int[,] tensionMatrix;

    //matrxi of modifications of tone. Subject to Change
    int[,] toneMatrix;

    // Use this for initialization
    void Start()
    {
        numAllies = 0;
        setTensionMatrix();
        initAllyArray();
        initQualitiesArray();
    }

    //initializes all the allies to null
    void initAllyArray()
    {
        allies = new Ally[] { null, null, null, null };
    }

    //initializes the music qualities array
    //Subject to Change
    void initQualitiesArray()
    {
        musicQualities = new float[] { 0.0f, 0.0f, 0.0f, 5.0f, 0.0f };
    }

    // Update is called once per frame
    void Update()
    {
        //adds the difference in time between this frame and the frame immediately before
        timeDiff += Time.deltaTime;
    }

    //plays a chord assigned to the key being pressed
    void playChord(int hotKeyIndex)
    {
        //plays the chord
        changeTension(hotKeys[hotKeyIndex]); //changes the tension level
        affectAllies(); //affects the allies
        prevChord = hotKeys[hotKeyIndex]; //sets this chord as the previous chord
        timeDiff = 0.0f;
    }

    //affects the allies and modifies their fields based on the music qualities
    private void affectAllies()
    {
        foreach (Ally a in allies)
        {
            if (a != null)
            {
                a.modifyAttributes(musicQualities);
            }
        }
    }

    //adds a new ally to the allies array.
    public void addAlly(Ally newAlly)
    {
        allies[numAllies] = newAlly;
        numAllies++;
    }

    //changes a single element on the hot keys array
    void changeHotKeys(int newChord, int index)
    {
        //if the index is too large for the hotKeys array, then print an error
        if (index > hotKeys.Length)
        {
            Debug.Log("Index too large");
            return;
        }
        hotKeys[index] = newChord;
    }

    //changes the whole hot keys array
    void changeHotKeys(int[] newHotKeys)
    {
        //if new array is bigger than the old array, then print an error
        if (newHotKeys.Length > hotKeys.Length)
        {
            Debug.Log("Index too large");
            return;
        }
        hotKeys = newHotKeys;
    }

    //changes to volume of the music
    //dir = 1, increase volume. dir = -1, decrease volume.
    //Subject to Change
    void changeVolume(int dir)
    {
        // if argument isn't 1 or -1, then print error
        if (dir != 1 && dir != -1)
        {
            Debug.Log("Incorrect Argument for changeVolume");
            return;
        }
        musicQualities[2] += dir;
    }

    //changes to tempo of the music
    //dir = 1, increase tempo. dir = -1, decrease tempo.
    //Subject to Change
    void changeTempo(int dir)
    {
        // if argument isn't 1 or -1, then print error
        if (dir != 1 && dir != -1)
        {
            Debug.Log("Incorrect Argument for changeTempo");
            return;
        }
        musicQualities[0] += dir;
    }

    //gets the tone modification based on the tone matrix
    int getToneMod()
    {
        return 0;
    }

    //sets the modification matrix for tone
    private void setToneMatrix()
    {
    }

    //creates the array of chords that could be played
    private string[] setChordArray()
    {
        return new string[24];
    }

    //changes the music tension based on the tension matrix
    void changeTension(int currentChord)
    {
        musicQualities[3] += tensionMatrix[prevChord, currentChord];
    }

    //creates the matrix of tension modifiers
    private void setTensionMatrix()
    {
        tensionMatrix = new int[,]{{ 0,  0,  0,  0,  5,  4,  0,  0,  6,  1,  5,  1,  0,  0,  6,  2,  4,  0,  6,  3,  4,  2,  3,  0},
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
}
