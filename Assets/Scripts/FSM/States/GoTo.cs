﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : IState {

	private Vector3 _destination_pos;
	private GameObject _owner_gameobject;
	private Vector3 _actual_position;
	private float _start_time;
	private float _duration;
	private Vector3 _start_pos;

	public GoTo(GameObject owner_game_object, Vector3 actual_position, Vector3 destination, float _duration)
	{
		this._owner_gameobject = owner_game_object;
		this._destination_pos = destination;
		this._actual_position = actual_position;
		this._start_time = Time.time;
		this._duration = _duration;
	}

	public void Enter()
	{
		_start_pos = _actual_position;
		Debug.Log(_destination_pos);
		Debug.Log("going to!");
	}

	public void Execute()
	{
		float time_since_started = Time.time - _start_time;
		float ratio = time_since_started / _duration;
		_owner_gameobject.transform.position = Vector3.Lerp(_start_pos, _destination_pos, ratio);

	}
	public void Exit()
	{

	}
}
