using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMaker : MonoBehaviour {

	public bool is_being_used;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateBeer()
	{
		ResourcesManager.Instance.beer += 1;
	}
}
