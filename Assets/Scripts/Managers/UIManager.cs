using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text beer;
	public Text meat;
	public Text gold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		beer.text = ResourcesManager.Instance.beer.ToString();
		meat.text = ResourcesManager.Instance.meat.ToString();
		gold.text = ResourcesManager.Instance.gold.ToString();
	}
}
