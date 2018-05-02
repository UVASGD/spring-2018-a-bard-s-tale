using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemScript : EnemyScript {

	// Use this for initialization
	void Start () {
		basicAttackDmg = 1;
		currAttackCoolDown = 3;
		currAttackCoolDown = attackCoolDown;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
