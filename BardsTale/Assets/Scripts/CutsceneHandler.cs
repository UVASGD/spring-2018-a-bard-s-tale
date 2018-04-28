using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneHandler : MonoBehaviour {
	public Sprite[] sprites; //Set publically, in Unity
	public string nextScene;
	private int current;
	private Image currentImage;

	//Note: the size of sprites

	public string[] texts;//Set publically, in Unity
	private Text currentText;

	// Use this for initialization
	void Start () {
		currentImage = this.GetComponent<Image>();
		currentText = this.transform.Find("TextBox").GetComponentInChildren<Text>();
		current = 0;
		currentImage.sprite = sprites[current];
		currentText.text = texts[current];
		current++;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)) {
			if(current==sprites.Length)
				SceneManager.LoadScene(nextScene);
			else {
				currentImage.sprite = sprites[current];
				currentText.text = texts[current];
				current++;
			}
		}
	}
}
