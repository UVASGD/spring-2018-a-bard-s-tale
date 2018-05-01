using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitionManager {

    

    public static bool sceneTransition(bool intendedValue)
    {
        int sceneNum = 0;
        for (int i = 0; i < GAMESTATS.scenesList.Length; i++)
        {
            if (GAMESTATS.scenesList[i].Equals(GAMESTATS.currentScene))
            {
                sceneNum = i;
            }
        }
        sceneNum++;
        if (GAMESTATS.scenesList[sceneNum].Contains("B")) //all battle scenes contain a capital "B", all other scene names have lowercase letters only
        {
            GAMESTATS.isBattle = true;
        }
        else
        {
            GAMESTATS.isBattle = false;
        }
        GAMESTATS.currentScene = GAMESTATS.scenesList[sceneNum];
        SceneManager.LoadScene(GAMESTATS.scenesList[sceneNum]);
        return intendedValue;
    }
}
