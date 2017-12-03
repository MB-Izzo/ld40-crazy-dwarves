using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	protected bool _is_being_used;
	public bool is_being_used { get { return _is_being_used; } set { this._is_being_used = value; } }


	public virtual void Use()
	{
		FindObjectOfType<AudioManager>().Play("bloop");
	}


	public virtual void StartUse()
	{
		_is_being_used = true;
	}

	public virtual void StopUse()
	{
		_is_being_used = false;
	}


}
