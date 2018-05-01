using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextBoxHandler : MonoBehaviour {
	//Used to set text boxes appearing!
	public Transform textPrefab; //Always to be set
	// Use this for initialization
	private Transform[] boxes;
	private bool[] used;
	private static string end = "\n Press (space) to continue";
	int numOfBox=2;
	int active;
	void Start () {
		//Here 2 is an arbitrary number; for actual scenes, you can set to whatever
		boxes = new Transform[numOfBox];
		used = new bool[numOfBox];
		for(int i = 0; i<numOfBox; ++i) {
			used[i]=false;
		}
		active=-1;
	}

	// Update is called once per frame
	void Update () {
		//Examples of what you can do!
		if(active==-1) {
			if(Time.timeSinceLevelLoad>=5.0f) {
				set(0,"Testing for 5 seconds!");
			}
			else if(Input.GetKeyDown(KeyCode.A)) {
				set(1,"Testing for A!");
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space)) {
				Destroy(boxes[active].gameObject);
				active=-1;
			}
		}
	}

	private void set(int i, string s) {
		if(!used[i]) {
			used[i]=true;
			boxes[i]=Instantiate(textPrefab,this.transform);
			boxes[i].position-=this.transform.position;
			boxes[i].GetComponent<TextBox>().setMessage(s+end);

			active=i;
		}
	}
}
