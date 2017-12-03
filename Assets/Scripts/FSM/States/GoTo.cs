using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : IState {

	private Vector3 _destination_pos;
	private GameObject _owner_gameobject;
	private Vector3 _initial_position;
	private float _start_time;
	private Vector3 _start_pos;
	private float _speed;
	private Building _building;

	public GoTo(GameObject owner_game_object, Vector3 destination, float speed, Building b=null)
	{
		this._owner_gameobject = owner_game_object;
		this._destination_pos = destination;
		this._initial_position = _owner_gameobject.transform.position;
		this._start_time = Time.time;
		this._speed = speed;
		this._building = b;
	}

	public void Enter()
	{
		_start_pos = _initial_position;
	}

	public IState Execute()
	{
        // TODO: Time Manager.
		_owner_gameobject.transform.position = Vector3.MoveTowards(_start_pos, new Vector3(_destination_pos.x, 0.5f, _destination_pos.z), _speed * Time.deltaTime);
		if (_owner_gameobject.transform.position.x == _destination_pos.x && _building != null)
		{
        	return new UseBuilding(_owner_gameobject, _building);
		}
		if (_building.is_being_used)
		{
			return new Idle(_owner_gameobject, new Vector3(0, 0.5f, 0), 2f);
		}
		return null;
	}

    public void Exit()
	{

	}

    public eStateType GetStateType()
    {
        return eStateType.moving;
    }
}
