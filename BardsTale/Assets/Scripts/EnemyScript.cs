using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : NPCScript
{
    public float attackCoolDown;
    protected float currAttackCoolDown;

    void Update()
    {
        if (!dead)
        {
            if (currAttackCoolDown < 0)
            {
                int randIndex = (int)(Random.Range(0, GAMESTATS.friends.Length));
                basicAttack(GAMESTATS.friends[randIndex]);
                currAttackCoolDown = attackCoolDown;
            }
            else
            {
                currAttackCoolDown -= Time.deltaTime;
            }
        }
    }

    public override void basicAttack(GameObject target)
    {
        if (target.GetComponent<Action>().amBard)
        {
            HealthScript targetHealth = target.GetComponent<HealthScript>();
            targetHealth.takeDamage(basicAttackDmg);
            Debug.Log(this.name + " Basic Attack " + target.name);
        }
        else
        {
            StaminaScript targetHealth = target.GetComponent<StaminaScript>();
            targetHealth.useStamina(basicAttackDmg);
            Debug.Log(this.name + " Basic Attack " + target.name);
        }
    }
}
