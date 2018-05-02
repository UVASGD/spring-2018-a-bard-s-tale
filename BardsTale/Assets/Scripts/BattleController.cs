using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour 
{
    public GameObject player;

    public GameObject[] allies;
    public GameObject[] enemies;

    public Slider momentum;

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

        if (Input.GetKeyDown("b"))
        {
            int randIndex = (int)(Random.Range(0, enemies.Length));
            allies[0].GetComponent<BarbarianScript>().basicAttack(enemies[randIndex]);
        }
        if (Input.GetKeyDown("n"))
        {
            int randIndex = (int)(Random.Range(0, enemies.Length));
            allies[0].GetComponent<BarbarianScript>().heavyAttack(enemies[randIndex]);
        }
        if (Input.GetKeyDown("m"))
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
            if (debug_mode)
                Debug.Log("Accessing friends at " + i + ": " + allies[i]);
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
                if (debug_mode)
                    Debug.Log(allies[i].GetComponent<HealthScript>().getHealthStats()[0] + ", " + allies[i].GetComponent<HealthScript>().getHealthStats()[1]);
                totalAllyHealth += GAMESTATS.friends[i].GetComponent<HealthScript>().getHealthStats()[0];
                maxAllyHealth += GAMESTATS.friends[i].GetComponent<HealthScript>().getHealthStats()[1];
            }
            else
            {
                if (debug_mode)
                    Debug.Log(allies[i].GetComponent<StaminaScript>().getStaminaStats()[0] + ", " + allies[i].GetComponent<StaminaScript>().getStaminaStats()[1]);
                totalAllyHealth += GAMESTATS.friends[i].GetComponent<StaminaScript>().getStaminaStats()[0];
                maxAllyHealth += GAMESTATS.friends[i].GetComponent<StaminaScript>().getStaminaStats()[1];
            }
        }
        AllyHealthRatio = (float)totalAllyHealth / maxAllyHealth;

        if(debug_mode)
            Debug.Log("Ally Health: " + AllyHealthRatio);

        int totalEnemyHealth = 0;
        int maxEnemyHealth = 1;
        float EnemyHealthRatio = 0.0f;
        for (int j = 0; j < enemies.Length; j++)
        {
            totalEnemyHealth += GAMESTATS.enemies[j].GetComponent<HealthScript>().getHealthStats()[0];
            maxEnemyHealth += GAMESTATS.enemies[j].GetComponent<HealthScript>().getHealthStats()[1];
        }
        EnemyHealthRatio = (float)totalEnemyHealth / maxEnemyHealth;

        if (debug_mode)
            Debug.Log("Enemy Health: " + EnemyHealthRatio);

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
        momentum.maxValue = 1;
        momentum.minValue = 0;
        momentum.value = (AllyHealthRatio - EnemyHealthRatio + 1) / 2;

        if (momentum.value > 0.8)
        {
            SceneTransitionManager.sceneTransition(true); //game is won, move forward
        }

        if (GAMESTATS.friends[0].GetComponent<HealthScript>().dead)
        {
            SceneTransitionManager.sceneTransition(true); //bard is dead, move forward
        }
    }
}
