using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

	private static ResourcesManager _instance;
	public static ResourcesManager Instance { get { return _instance; } }

	public int beer;

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
	}

	public bool NeedBeer()
	{
		return beer < 5;
	}
	
}
