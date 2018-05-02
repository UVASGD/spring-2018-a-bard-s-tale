using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    public bool amBard;
    public bool havingMercy;
    public bool retreating;

    public bool staying;
    public bool aggro;

    public float cooldown = 0;

    // Use this for initialization
    void Start()
    {
        bool havingMercy = false;
        bool retreating = false;
        bool staying = false;
        bool aggro = false;
    }

	
	// Update is called once per frame
	void Update () {
        if (cooldown < 0)
        {
            switch (GetComponent<Personality>().attitude)
            {
                case "Terrified":
                    //retreat
                    Debug.Log("Terrified- retreating if possible");
                    retreat();
                    break;
                case "Curious":
                    //safe attack
                    Debug.Log("Curious- normal attack");
                    attack();
                    break;
                case "Defeated":
                    //defense
                    Debug.Log("Defeated- defending");
                    defend();
                    break;
                case "Determined":
                    //reckless attack
                    Debug.Log("Determined- reckless attack");
                    reckless_attack();
                    break;
                case "Alert":
                    //defense
                    Debug.Log("Alert- defending");
                    defend();
                    break;
                case "Cautious":
                    //safe attack
                    Debug.Log("Cautious- normal attack");
                    attack();
                    break;
                case "Relenting":
                    //mercy
                    Debug.Log("Relenting - have mercy");
                    mercy();
                    break;
                case "Victorious":
                    //strong attack
                    Debug.Log("Victorious - strong attack");
                    strong_attack();
                    break;
                case "Nervous":
                    //stay in place
                    Debug.Log("Nervous - stay put");
                    stay();
                    break;
                case "Foreboding":
                    //enter battle
                    Debug.Log("Foreboding- enter battle");
                    battle();
                    break;
                case "Hopeless":
                    //avoid battle
                    Debug.Log("Hopeless- avoid battle");
                    avoid_battle();
                    break;
                case "Determination":
                    //onwards
                    Debug.Log("Determination- move forward");
                    move();
                    break;
                case "Hopeful":
                    //avoid battle
                    Debug.Log("Hopeful- avoid battle");
                    avoid_battle();
                    break;
                case "Excited":
                    //enter battle
                    Debug.Log("Excited- enter battle");
                    battle();
                    break;
                case "Content":
                    //stay
                    Debug.Log("Content- stay put");
                    stay();
                    break;
                case "Elated":
                    //shop
                    Debug.Log("Elated- shop");
                    shop();
                    break;
                case "":
                    //No emotion
                    Debug.Log("ERROR: No Emotion");
                    break;

            }
            cooldown = 2;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
        
	}

    //Looks for shopping opportunities, if unavailable, moves on
    private void shop()
    {
        if (GAMESTATS.isShop)
        {
            // open shop dialogue //Don't need this for demo, not doing it til later.
        }
        else
        {
            staying = false;
        }
    }

    //Moves on
    private void move()
    {
        staying = false;
    }

    //Stays put and reduces total tension. Heals if unmoving.
    private void avoid_battle()
    {
        staying = true;
        if (amBard)
        {
            GetComponent<HealthScript>().takeDamage(-1);
        }
        else
        {
            GetComponent<StaminaScript>().useStamina(-1);
        }
    }

    //If battle is available, enters battle. If unavailable, moves on.
    private void battle()
    {
        aggro = true;
    }

    //Stays put. If stopped, seeks rest/healing
    private void stay()
    {
        staying = true;
        if (amBard)
        {
            GetComponent<HealthScript>().takeDamage(-1);
        }
        else
        {
            GetComponent<StaminaScript>().useStamina(-1);
        }
    }

    //Strong attack- costs stamina, but does like 2 damage.
    private void strong_attack()
    {
        retreating = false;
        havingMercy = false;
        if (!amBard)
        {
            System.Random rand = new System.Random();
            GameObject enemy = GAMESTATS.enemies[rand.Next(GAMESTATS.enemies.Length) - 1];
            if (true) /*replace this with a check to see if enemy is alive */
            {
                GetComponent<movement>().moveTo(new Vector2(enemy.transform.position.x, enemy.transform.position.y));
                GetComponent<BarbarianScript>().heavyAttack(enemy);
            }
        }
    }

    //No attack, defend bonus. If the enemy can't attack, ends battle.
    private void mercy()
    {
        retreating = false;
        if (!amBard)
        {
            GetComponent<BarbarianScript>().defend();
        }
        havingMercy = true;
    }

    //All-out attack- costs same stamina as normal attack, but either does 2 or 0 damage.
    private void reckless_attack()
    {
        retreating = false;
        havingMercy = false;
        if (!amBard)
        {
            System.Random rand = new System.Random();
            GameObject enemy = GAMESTATS.enemies[rand.Next(GAMESTATS.enemies.Length) - 1];
            if (true) /*replace this with a check to see if enemy is alive */
            {
                GetComponent<movement>().moveTo(new Vector2(enemy.transform.position.x, enemy.transform.position.y));
                GetComponent<BarbarianScript>().recklessAttack(enemy);
            }
        }
    }

    //No action- restores stamina, prompts blocks
    private void defend()
    {
        retreating = false;
        havingMercy = false;
        if (!amBard)
        {
            GetComponent<BarbarianScript>().defend();
        }
    }

    //Costs 1 stamina, does 1 damage. Simple attack.
    private void attack()
    {
        retreating = false;
        havingMercy = false;
        if (!amBard)
        {
            System.Random rand = new System.Random();
            GameObject enemy = GAMESTATS.enemies[rand.Next(GAMESTATS.enemies.Length) - 1];
            if (true) /*replace this with a check to see if enemy is alive */
            {
                GetComponent<movement>().moveTo(new Vector2(enemy.transform.position.x, enemy.transform.position.y));
                GetComponent<BarbarianScript>().recklessAttack(enemy);
            }
        }
    }

    //No action. If alive next turn, ends battle.
    private void retreat()
    {
        havingMercy = false;
        if (!amBard)
        {
            GetComponent<BarbarianScript>().defend();
        }
        retreating = true;
    }
}
