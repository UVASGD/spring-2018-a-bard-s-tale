using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Create two scenes:
 *      Scene1
 *      Scene2
 * (( change the scene names in the code if you want to use different scene names ))
 * 
 * Go to file --> build settings --> drag and drop the two scenes
 * Exit (don't press build or build & run)
 * 
 * Add the scripts to the main camera in their respective scripts
 * 
*/

public class ChangeScene1 : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        /*
        string name = SceneManager.GetActiveScene().name;
        print("name");
        */

        if (Input.GetKeyDown("space")){
            Application.LoadLevel("Scene2");
        }
		
	}
}
