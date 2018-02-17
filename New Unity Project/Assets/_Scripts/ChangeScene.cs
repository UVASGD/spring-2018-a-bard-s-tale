using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene1 : MonoBehaviour { 	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space")){
            Application.LoadLevel("Scene2");
        }
		
	}
}
