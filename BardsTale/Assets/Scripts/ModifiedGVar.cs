using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifiedGVar : MonoBehaviour {

	// Keybindings data
	public Canvas ui;

	private Image[] onArray;
	private Text[] valArray;
	private GameObject hotbar;
	private bool hotbarHidden;
	//Sliders data
	public Toggle battletime;
	public Slider TSlide;
	public Slider VSlide;
	public Image momentumBar;

	private Sprite fullHeart;
	private Sprite emptyHeart;
	private Image[] hearts;
	private GameObject healthbar;
	private const int maxHearts = 3;
	private int currHeart;

	// Use this for initialization
	void Start () {

		initHearts();

		momentumBar.fillAmount = 0.5f;
		hotbarHidden=false;
		hotbar = ui.transform.Find("Hotbar").gameObject;
		GameObject[] hotkeys = new GameObject[6];
		hotkeys[0] = hotbar.transform.Find("A").gameObject;
		hotkeys[1] = hotbar.transform.Find("S").gameObject;
		hotkeys[2] = hotbar.transform.Find("D").gameObject;
		hotkeys[3] = hotbar.transform.Find("F").gameObject;
		hotkeys[4] = hotbar.transform.Find("G").gameObject;
		hotkeys[5] = hotbar.transform.Find("H").gameObject;

		onArray = new Image[6];
		valArray = new Text[6];


		for(int i = 0; i< 6; i++) {
			onArray[i]=hotkeys[i].GetComponentInChildren<Image>();
			valArray[i]=hotkeys[i].GetComponentInChildren<Text>();
		}

	}

	// Update is called once per frame
	void Update () {

		//Hotbar is pressed down
		if(Input.GetKeyDown(KeyCode.A)) {
			onArray[0].color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.S)) {
			onArray[1].color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.D)) {
			onArray[2].color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.F)) {
			onArray[3].color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.G)) {
			onArray[4].color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.H)) {
			onArray[5].color = Color.green;
		}

		//Hotbar is released
		if(Input.GetKeyUp(KeyCode.A)) {
			onArray[0].color = Color.red;
		}
		if(Input.GetKeyUp(KeyCode.S)) {
			onArray[1].color = Color.red;
		}
		if(Input.GetKeyUp(KeyCode.D)) {
			onArray[2].color = Color.red;
		}
		if(Input.GetKeyUp(KeyCode.F)) {
			onArray[3].color = Color.red;
		}
		if(Input.GetKeyUp(KeyCode.G)) {
			onArray[4].color = Color.red;
		}
		if(Input.GetKeyUp(KeyCode.H)) {
			onArray[5].color = Color.red;
		}

		if(Input.GetKeyDown(KeyCode.Tab)) {
			if(!hotbarHidden) {
				hotbar.transform.Translate(new Vector3(-500f,500f,0f));
				hotbarHidden = !hotbarHidden;
			}
			else {
				hotbar.transform.Translate(new Vector3(500f,-500f,0f));
				hotbarHidden = !hotbarHidden;
			}
		}
		//The following are just for testing
		if (Input.GetKeyDown(KeyCode.E)) {
			momentumBar.fillAmount += .1f;
		}

		if(Input.GetKeyDown(KeyCode.W)) {
			momentumBar.fillAmount -= .1f;
		}

		if(Input.GetKeyDown(KeyCode.Z)) {
			setHealth(1);
		}

		if(Input.GetKeyDown(KeyCode.X)) {
			setHealth(2);
		}

		if(Input.GetKeyDown(KeyCode.C)) {
			setHealth(3);
		}
	}

	private void initHearts() {
		fullHeart = Resources.Load <Sprite> ("Sprites/Full_Heart");
		emptyHeart = Resources.Load <Sprite> ("Sprites/Empty_Heart");
		healthbar = ui.transform.Find("Healthbar").gameObject;
		hearts = new Image[maxHearts];
		for(int i = 0; i < maxHearts; ++i) {
			hearts[i] = healthbar.transform.Find("Heart "+(i+1)).GetComponent<Image>();
		}
	}

	private void setHealth(int m) {
		if(m<0)
			m=0;
		if(m>maxHearts)
			m=maxHearts;
		int i=0;
		for(; i< m; ++i)
			hearts[i].sprite =fullHeart;
		for(; i<maxHearts; ++i)
			hearts[i].sprite = emptyHeart;
	}
}
