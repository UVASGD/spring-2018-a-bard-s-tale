using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructor : MonoBehaviour {

    public bool enemy = false;

	// Use this for initialization
	void Awake () {
        Debug.Log("Constructor method called, enemy is :" + enemy);
		if (enemy)
        {
            GameObject[] temp = new GameObject[GAMESTATS.enemies.Length + 1];
            for (int i = 0; i < GAMESTATS.enemies.Length; i++)
            {
                temp[i] = GAMESTATS.enemies[i];
            }
            temp[GAMESTATS.enemies.Length] = gameObject;
            GAMESTATS.enemies = temp;
            GAMESTATS.isBattle = true;
        }
        else
        {
            GameObject[] temp = new GameObject[GAMESTATS.friends.Length + 1];
            for (int i = 0; i < GAMESTATS.friends.Length; i++)
            {
                temp[i] = GAMESTATS.friends[i];
            }
            temp[GAMESTATS.friends.Length] = gameObject;
            GAMESTATS.friends = temp;
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
