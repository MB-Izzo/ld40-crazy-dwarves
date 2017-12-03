using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : Building {

	private int meat_stock { get { return ResourcesManager.Instance.meat; } }
	public GameObject anim_to_play;


	public override void Use()
	{
		ResourcesManager.Instance.meat += 1;
		Vector3 pos_to_play = new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z);
		Instantiate(anim_to_play, pos_to_play, Quaternion.identity);
		base.Use();

	}
}
