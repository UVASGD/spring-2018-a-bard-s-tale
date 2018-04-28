using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public Slider staminaSlider;

    public int maxStamina;

    private int currStamina;

    private float stamRecharge = 1.5f;
    private float currStamRecharge;

    // Use this for initialization
    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        currStamina = maxStamina;

        staminaSlider.value = currStamina;

        currStamRecharge = stamRecharge;
    }

    void Update()
    {
        //stamina recharge
        if (currStamina < maxStamina)
        {
            if (currStamRecharge < 0)
            {
                currStamina += 1;
                staminaSlider.value = currStamina;
                currStamRecharge = stamRecharge;
            }
            else
            {
                currStamRecharge -= Time.deltaTime;
            }
        }
    }

    public void useStamina(int stam)
    {
        currStamina -= stam;
        staminaSlider.value = currStamina;
    }
}
