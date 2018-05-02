using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour 
{
    public GameObject player;

    public GameObject[] allies;
    public GameObject[] enemies;

    public bool debug_mode = false;

	// Use this for initialization
	void Start () {
        allies = GAMESTATS.friends;
        enemies = GAMESTATS.enemies;

        string allyList = "Allies: ";
        foreach (GameObject a in allies)
        {
            allyList += a.name + " ";
        }

        string enemyList = "Enemies: ";
        foreach (GameObject e in enemies)
        {
            enemyList += e.name + " ";
        }

        Debug.Log(allyList);
        Debug.Log(enemyList);
    }
	
	// Update is called once per frame
	void Update ()
    {
        allies = GAMESTATS.friends;
        enemies = GAMESTATS.enemies;
        checkOnActions();

        if (Input.GetKeyDown("a"))
        {
            int randIndex = (int)(Random.Range(0, enemies.Length));
            allies[0].GetComponent<BarbarianScript>().basicAttack(enemies[randIndex]);
        }
        if (Input.GetKeyDown("s"))
        {
            int randIndex = (int)(Random.Range(0, enemies.Length));
            allies[0].GetComponent<BarbarianScript>().heavyAttack(enemies[randIndex]);
        }
        if (Input.GetKeyDown("d"))
        {
            int randIndex = (int)(Random.Range(0, enemies.Length));
            allies[0].GetComponent<BarbarianScript>().recklessAttack(enemies[randIndex]);
        }
    }

    void checkOnActions()
    {
        bool everyoneMercy = true;
        bool everyoneRetreat = true;
        bool enemiesWeakEnough = false;
        bool alliesStrongEnough = false;
        int totalAllyHealth = 0;
        int maxAllyHealth = 1;
        float AllyHealthRatio = 0.0f;
        if (debug_mode)
        {
            Debug.Log("This many allies: " + allies.Length);
            Debug.Log("Gamestats says there are " + GAMESTATS.friends.Length + " allies.");
        }
        
        for (int i = 0; i < allies.Length; i++)
        {
            if (allies[i].GetComponent<Action>().havingMercy == false)
            {
                everyoneMercy = false;
            }
            if (allies[i].GetComponent<Action>().retreating == false)
            {
                everyoneRetreat = false;
            }
            if (allies[i].GetComponent<Action>().amBard)
            {
                totalAllyHealth += allies[i].GetComponent<HealthScript>().getHealthStats()[0];
                maxAllyHealth += allies[i].GetComponent<HealthScript>().getHealthStats()[1];
            }
            else
            {
                totalAllyHealth += allies[i].GetComponent<StaminaScript>().getStaminaStats()[0];
                maxAllyHealth += allies[i].GetComponent<StaminaScript>().getStaminaStats()[1];
            }
        }
        AllyHealthRatio = totalAllyHealth / maxAllyHealth;

        int totalEnemyHealth = 0;
        int maxEnemyHealth = 1;
        float EnemyHealthRatio = 0.0f;
        for (int j = 0; j < enemies.Length; j++)
        {
            totalEnemyHealth += enemies[j].GetComponent<HealthScript>().getHealthStats()[0];
            maxEnemyHealth += enemies[j].GetComponent<HealthScript>().getHealthStats()[1];
        }
        EnemyHealthRatio = totalEnemyHealth / maxEnemyHealth;

        enemiesWeakEnough = EnemyHealthRatio < 0.2;
        alliesStrongEnough = AllyHealthRatio > 0.2;

        if (everyoneMercy && enemiesWeakEnough)
        {
            SceneTransitionManager.sceneTransition(true); //have mercy, move forward
        }
        if (everyoneRetreat && alliesStrongEnough)
        {
            SceneTransitionManager.sceneTransition(true); //retreat, move forward !? 
            //(right now, sceneTransition() doesn't work for moving backwards, but it shouldn't matter for the demo.)
        }


    }
}
