using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {

	private float t;
	private bool game_win;
	public GameObject game_win_panel;
	public GameObject game_lose_panel;
	public Text text;

	// Use this for initialization
	void Start () {
		game_win =false;
		t=300;
	}
	
	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;
		int a;
		a = (int)t;
		text.text = a.ToString();
		if (ResourcesManager.Instance.beer >= 100
		&& ResourcesManager.Instance.meat >= 100
		&& ResourcesManager.Instance.gold >= 150)
		{
			game_win = true;
		}
		if (game_win)
		{
			Time.timeScale = 0;
			game_win_panel.SetActive(true);
			t=300;
		}
		if(t == 0)
		{
			game_lose_panel.SetActive(true);
		}
	}

	
}
