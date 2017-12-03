using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : Building {

	public GameObject anim_to_play;
	private int _meat { get { return ResourcesManager.Instance.meat; } set { ResourcesManager.Instance.meat = value;}}
	private int _gold { get { return ResourcesManager.Instance.gold; } set { ResourcesManager.Instance.gold = value;}}
	private int _beer { get { return ResourcesManager.Instance.beer; } set { ResourcesManager.Instance.beer = value;}}
	private int _nbr_to_sell { get { return ResourcesManager.Instance.nbr_to_sell;} }

	public override void Use()
	{
		if (_meat >= _nbr_to_sell)
		{
			_meat-=_nbr_to_sell;
			_gold+=_nbr_to_sell;
			Vector3 pos_to_play = new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z);
			Instantiate(anim_to_play, pos_to_play, Quaternion.identity);
		}
		if (_beer >=_nbr_to_sell)
		{
			_beer-=_nbr_to_sell;
			_gold+=_nbr_to_sell*2;
			Vector3 pos_to_play = new Vector3(transform.position.x + 0.5f, transform.position.y + 1, transform.position.z);
			Instantiate(anim_to_play, pos_to_play, Quaternion.identity);
		}
		FindObjectOfType<AudioManager>().Play("coin");


	}
}
