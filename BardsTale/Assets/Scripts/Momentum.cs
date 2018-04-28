
using UnityEngine;
using UnityEngine.UI;

public class Momentum : MonoBehaviour
{
    public Slider momentumSlider;

    public GameObject person;
    public GameObject[] allies;
    public GameObject[] enemies;

    private float playerHealth;
    private float[] allyHealths;
    private float[] enemyHealths;

    void Start()
    {
        playerHealth = 100;

        allyHealths = new float[allies.Length];
        for(int i = 0; i < allies.Length; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        momentumSlider.value += Input.GetAxis("Horizontal") * Time.deltaTime;
    }
}
