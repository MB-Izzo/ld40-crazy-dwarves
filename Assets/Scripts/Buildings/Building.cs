﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	protected bool _is_being_used;
	public bool is_being_used { get { return _is_being_used; } set { this._is_being_used = value; } }
	public bool someone_travaling_to { get { return _is_being_used; } set { this._is_being_used = value; } }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Use()
	{
		_is_being_used = true;
	}

	public virtual void StopUse()
	{
		_is_being_used = false;
	}
}
