using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour {

    public GameObject thisSprite;

    public float speed;

    Vector3 pos;
	
	// Update is called once per frame
	void Update () {
        pos = thisSprite.transform.position;

        thisSprite.transform.Translate(pos * speed * Time.deltaTime);
		
	}
}
