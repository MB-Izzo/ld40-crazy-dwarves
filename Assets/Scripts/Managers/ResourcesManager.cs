using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

	private static ResourcesManager _instance;
	public static ResourcesManager Instance { get { return _instance; } }

	public int beer;
	public int meat;
	public int gold;

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
		return beer < 10;
	}
	
	public bool NeedMeat()
	{
		return meat < 10;
	}

	public bool CanSell()
	{
		return meat >=2 && beer >= 2;
	}

	private void Update() {

	}
	
}
