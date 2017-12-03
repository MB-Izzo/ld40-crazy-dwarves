using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMaker : Building {

	private int beer_stock { get { return ResourcesManager.Instance.beer; } }
	public GameObject anim_to_play;
	public int beer_to_produce { get { return ResourcesManager.Instance.beer_to_produce; }}

	public override void Use()
	{
		ResourcesManager.Instance.beer += beer_to_produce;
		Vector3 pos_to_play = new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z);
		Instantiate(anim_to_play, pos_to_play, Quaternion.identity);
		base.Use();
	}

}
