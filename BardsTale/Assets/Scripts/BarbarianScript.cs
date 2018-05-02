using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianScript : MonoBehaviour
{
    private StaminaScript stamina;

    private bool defending = false;

    private int basicAttackStam = 0;
    private int basicAttackDmg = 1;

    private int heavyAttackStam = 2;
    private int heavyAttackDmg = 2;

    private int recklessAttackStam = 1;
    private int recklessAttackDmg = 2;

    private float attackCoolDown = 1;
    private float currAttackCoolDown;

    void Start()
    {
        stamina = GetComponent<StaminaScript>();
        currAttackCoolDown = attackCoolDown;
    }

    public void defend()
    {
        defending = true;
    }

    public void basicAttack(GameObject target)
    {
        Debug.Log(this.name + " Basic Attack " + target.name);
        defending = false;
        HealthScript targetHealth = target.GetComponent<HealthScript>();
        targetHealth.takeDamage(basicAttackDmg);
        stamina.useStamina(basicAttackStam);
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
