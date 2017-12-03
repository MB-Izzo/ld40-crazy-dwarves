using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : Building {

	public override void Use()
	{
		ResourcesManager.Instance.meat -=1;
		ResourcesManager.Instance.beer -=1;
		ResourcesManager.Instance.gold +=2;
	}
}
