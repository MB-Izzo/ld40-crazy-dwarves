using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMaker : Building {


	public override void Use()
	{
		ResourcesManager.Instance.beer += 1;
	}
}
