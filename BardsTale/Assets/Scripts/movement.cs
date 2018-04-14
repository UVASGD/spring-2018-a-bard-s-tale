using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    // locations contains a string of coordinates, in the format "x_1 y_1 x_2 y_2 x_3 y_3" etc
    public Text locations;

    private Vector2 position;
    private string[] coords;
    private float[] coordsf;
    private int positionsCovered = 0;
    private float speed = 0.01f;

	// Use this for initialization
	void Start () {
        coords = locations.text.Split(' ');
        coordsf = new float[coords.Length];
        for (int i = 0; i < coordsf.Length; i++)
        {
            coordsf[i] = float.Parse(coords[i]);
        }

        position = new Vector2(0.0f, 0.0f);
        transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
        if (positionsCovered * 2 < coordsf.Length - 1)
        {
            bool xSat = Mathf.Abs(position.x - coordsf[positionsCovered * 2]) < 0.01f;
            bool ySat = Mathf.Abs(position.y - coordsf[positionsCovered * 2 + 1]) < 0.01f;

            if (!xSat && position.x != coordsf[positionsCovered * 2])
            {
                float difference = position.x - coordsf[positionsCovered * 2];
                position.x -= 0.01f * (difference / Mathf.Abs(difference));
            }

            if (!ySat && position.y != coordsf[positionsCovered * 2 + 1])
            {
                float difference = position.y - coordsf[positionsCovered * 2 + 1];
                position.y -= 0.01f * (difference / Mathf.Abs(difference));
            }

            if (xSat && ySat)
            {
                positionsCovered++;
            }
            transform.position = position;
            Debug.Log("Sprite position: " + position.x + ", " + position.y);
            Debug.Log("\tDebug info: xSat = " + xSat + " ySat = " + ySat + " positionsCovered = " + positionsCovered);
        }
	}
}
