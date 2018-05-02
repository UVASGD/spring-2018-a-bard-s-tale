using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianScript : Ally
{
    protected override void Start()
    {
        base.Start();

        basicAttackStam = 0;
        basicAttackDmg = 1;

        heavyAttackStam = 2;
        heavyAttackDmg = 2;

        recklessAttackStam = 1;
        recklessAttackDmg = 2;
    }
}
