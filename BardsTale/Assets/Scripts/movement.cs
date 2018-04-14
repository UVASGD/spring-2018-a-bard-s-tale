using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    // locations contains a string of coordinates, in the format "x_1 y_1 x_2 y_2 x_3 y_3" etc
    // target is another Sprite, and you just move to the other Sprite
    public Text locations;
    public Sprite target;
    public bool toLocation = false;
    public float speed = 0.1f;

    private Vector2 position;
    private string[] coords;
    private float[] coordsf;
    private int positionsCovered = 0;

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
            bool xSat = Mathf.Abs(position.x - coordsf[positionsCovered * 2]) < 0.1f;
            bool ySat = Mathf.Abs(position.y - coordsf[positionsCovered * 2 + 1]) < 0.1f;

            Vector2 dest = new Vector2(coordsf[positionsCovered * 2], coordsf[positionsCovered * 2 + 1]);
            float xdiff = dest.x - position.x;
            float ydiff = dest.y - position.y;

            float length = Mathf.Sqrt(Mathf.Pow(xdiff, 2) + Mathf.Pow(ydiff, 2));

            float unit_x = xdiff / length;
            float unit_y = ydiff / length;



            if (!xSat)
            {
                position.x += speed * unit_x / 10;
            }

            if (!ySat)
            {
                position.y += speed * unit_y / 10;
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
