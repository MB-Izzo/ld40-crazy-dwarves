using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMaker : Building {

	private int beer_stock { get { return ResourcesManager.Instance.beer; } }

	public override void Use()
	{
		ResourcesManager.Instance.beer += 1;
	}

}
