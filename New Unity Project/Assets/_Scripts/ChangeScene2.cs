using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene2 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            Application.LoadLevel("Scene1");
        }

    }
}
