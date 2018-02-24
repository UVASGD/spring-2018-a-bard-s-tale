using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject panel;
    public GameObject pauseButton;
	// Update is called once per frame
	void Update () { 

        if (Input.GetKeyDown("p"))
        {
            //paused = togglePause();
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
                showPaused();
            } else
            {
                Time.timeScale = 1.0f;
                hidePaused();
            }
        } 

        
	}

    void showPaused()
    {
        if  (panel.tag == "ShowOnPause")
        {
            panel.SetActive(true);
        }

        if (pauseButton.tag == "PauseButton")
        {
            pauseButton.SetActive(false);
        }
        
    }

    void hidePaused()
    {
        if (panel.tag == "ShowOnPause")
        {
            panel.SetActive(false);
        }


        if (pauseButton.tag == "PauseButton")
        {
            pauseButton.SetActive(true);
        }

    }
}
