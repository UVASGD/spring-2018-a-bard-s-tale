using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour 
{
    public GameObject player;

    public GameObject[] allies;
    public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            allies[0].GetComponent<BarbarianScript>().basicAttack(enemies[0]);
            Debug.Log("Basic Attack");
        }		
	}
}
