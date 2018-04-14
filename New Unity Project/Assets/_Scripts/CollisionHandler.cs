using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public GameObject player;
    public GameObject obstacle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision");
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I've collided!!!");
        player.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    */
}
