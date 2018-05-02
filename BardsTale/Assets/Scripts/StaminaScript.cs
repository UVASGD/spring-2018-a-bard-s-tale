using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public bool doingSlider = false;
    public Slider staminaSlider;

    public int maxStamina;

    private int currStamina;

    private float stamRecharge = 1.5f;
    private float currStamRecharge;

    // Use this for initialization
    void Start()
    {
        if (doingSlider)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = maxStamina;
        }
        currStamina = maxStamina;

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
                if (doingSlider)
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
        if ((stam != -1) && !GetComponent<Ally>().isDefending())
        {
            currStamina -= stam;
        }
        else
        {
            currStamina = maxStamina;
        }
        if (doingSlider)
            staminaSlider.value = currStamina;
    }

    public int[] getStaminaStats()
    {
        return new int[] { currStamina, maxStamina };
    }
}
