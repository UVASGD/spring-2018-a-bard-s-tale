using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Momentum : MonoBehaviour
{
    public Slider momentumSlider;

    //function to change momentum
    void changeMomentum(float dmg)
    {
        momentumSlider.value += dmg * Time.deltaTime;
    }
}