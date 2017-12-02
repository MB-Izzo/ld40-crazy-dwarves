using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

	private static BuildingManager _instance;
	public static BuildingManager Instance { get { return _instance; } }

	public List<Building> buildings { get; set; }

	// Use this for initialization
	void Start () {
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}

		buildings = new List<Building>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
