using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthSlider;

    public int maxHealth;

    private int currHealth;
    private bool dead;

    // Use this for initialization
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        currHealth = maxHealth;
        healthSlider.value = currHealth;
        dead = false;
    }

    public void takeDamage(int dmg)
    {
        if (!dead)
        {
            currHealth -= dmg;
            healthSlider.value = currHealth;
            if (currHealth < 0)
            {
                dead = true;
            }
        }
    }
}
