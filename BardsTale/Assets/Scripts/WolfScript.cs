using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : EnemyScript
{
    void Start ()
    {
        basicAttackDmg = 1;
        currAttackCoolDown = 2;
        currAttackCoolDown = attackCoolDown;	
	}
}
