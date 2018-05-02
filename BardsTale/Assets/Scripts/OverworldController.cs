using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldController : MonoBehaviour {

    public int stageNum = 0;
    public int numStages = 1;

    public GameObject[] flags = new GameObject[] { null };

    // Use this for initialization
    void Start () {
		if (flags.Length != numStages)
        {
            Debug.Log("RISK: there seem to be a different number of flags from the specified maximum number of stages.");
        }
        else
        {
            Debug.Log("GOOD: there seem to be an equal number of flags as stages.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //gets a feel for what the crew is thinkin'
        poll();
	}

    void poll()
    {
        bool everyoneMoving = true;
        bool everyoneAggro = true;
        for (int i = 0; i < GAMESTATS.friends.Length; i++)
        {
            if (GAMESTATS.friends[i].GetComponent<Action>().staying)
            {
                everyoneMoving = false;
            }
            if (GAMESTATS.friends[i].GetComponent<Action>().aggro == false)
            {
                everyoneAggro = false;
            }
        }

        //prioritize fighting over moving along
        if (everyoneAggro)
        {
            givesYouHell();
        }
        else if (everyoneMoving)
        {
            moveAlong();
        }
        else
        {
            timeStandsStill();
        }
        
    }

    //moves the crew to the next flag- gonna have to have separate scripts for those flags to have things happen (like dialogue)
    void moveToStage(int number)
    {
        for (int i = 0; i < GAMESTATS.friends.Length; i++)
        {
            GAMESTATS.friends[i].GetComponent<movement>().moveTo(new Vector2(flags[number].transform.position.x, flags[number].transform.position.y));
        }
    }

    void moveAlong()
    {
        if (stageNum == numStages)
        {
            SceneTransitionManager.sceneTransition(true);
        }
        else
        {
            stageNum++;
            moveToStage(stageNum);
        }
    }

    void timeStandsStill()
    {
        // do nothing- wants to heal or rest or something, which is handled by Action.cs
    }

    void givesYouHell()
    {
        moveAlong(); //don't currently have any scene where you fight when you could be moving on, so for now givesYouHell() and moveAlong() are the same thing.
    }
}
