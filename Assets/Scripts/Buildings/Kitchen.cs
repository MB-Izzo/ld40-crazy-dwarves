using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : Building {

	private int meat_stock { get { return ResourcesManager.Instance.meat; } }
	public GameObject anim_to_play;


	public override void Use()
	{
		ResourcesManager.Instance.meat += 1;
		Instantiate(anim_to_play, transform.position, Quaternion.identity);
	}
}
