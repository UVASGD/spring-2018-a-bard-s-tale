using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCScript : MonoBehaviour
{
    protected int basicAttackDmg;

    protected bool dead;

    public void kill()
    {
        Debug.Log(name + " is Dead");
        dead = true;
    }

    public virtual void basicAttack(GameObject target)
    {
        Debug.Log(this.name + " Basic Attack " + target.name);
        HealthScript targetHealth = target.GetComponent<HealthScript>();
        targetHealth.takeDamage(basicAttackDmg);
    }
}
