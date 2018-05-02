using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneHandler : MonoBehaviour {
	public Sprite[] sprites; //Set publically, in Unity
	public string nextScene;
	private int current;
	public Image currentImage;

	//Note: the size of sprites

	public string[] texts;//Set publically, in Unity
	public Text currentText;

	// Use this for initialization
	void Start () {
		//currentImage = this.GetComponent<Image>();
		//currentText = this.transform.Find("TextBox").GetComponentInChildren<Text>();
		current = 0;
		currentImage.sprite = sprites[current];
		currentText.text = texts[current];
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if(current==sprites.Length-1)
				SceneTransitionManager.sceneTransition(true);
			else {
				current++;
				currentImage.sprite = sprites[current];
				currentText.text = texts[current];
			}
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			if(current!=0) {
				current--;
				currentImage.sprite = sprites[current];
				currentText.text = texts[current];
			}
		}
	}
}
