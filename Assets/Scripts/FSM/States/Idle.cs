using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{

	private GameObject _owner_gameobject;
	private Vector3 _destination_pos;
	private Vector3 _start_pos;
	private float _speed;

	public Idle(GameObject owner_gameobject, Vector3 destination, float speed)
	{
		this._owner_gameobject = owner_gameobject;
		this._destination_pos = destination;
		this._speed = speed;
	}

	public void Enter()
	{
		
	}
	public IState Execute()
	{
		// GO TO IDLE ROOM
		_start_pos = _owner_gameobject.transform.position;
		_owner_gameobject.transform.position = Vector3.MoveTowards(_start_pos, new Vector3(_destination_pos.x, 0.5f, _destination_pos.z), _speed * Time.deltaTime);
		return null;
	}
		
	public void Exit()
	{

	}

	public eStateType GetStateType()
	{
		return eStateType.idle; 
	}
}

