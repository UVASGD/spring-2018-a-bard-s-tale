using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ally : NPCScript
{
    protected StaminaScript stamina;

    protected bool defending = false;

    protected int basicAttackStam;

    protected int heavyAttackStam;
    protected int heavyAttackDmg;

    protected int recklessAttackStam;
    protected int recklessAttackDmg;

    protected virtual void Start()
    {
        stamina = GetComponent<StaminaScript>();
    }

    public void defend()
    {
        defending = true;
    }

    public bool isDefending()
    {
        return defending;
    }

    public override void basicAttack(GameObject target)
    {
        defending = false;
        base.basicAttack(target);
    }

    public void heavyAttack(GameObject target)
    {
        Debug.Log(this.name + " Heavy Attack " + target.name);
        defending = false;
        HealthScript targetHealth = target.GetComponent<HealthScript>();
        targetHealth.takeDamage(heavyAttackDmg);
        stamina.useStamina(heavyAttackStam);
    }

    public void recklessAttack(GameObject target)
    {
        Debug.Log(this.name + " Reckless Attack " + target.name);
        defending = false;
        HealthScript targetHealth = target.GetComponent<HealthScript>();
        targetHealth.takeDamage(recklessAttackDmg);
        stamina.useStamina(recklessAttackStam);
    }
}
