using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBuilding : IState {

	private Building _building;
	private float t;
	private GameObject _owner_gameobject;

	public UseBuilding(GameObject owner_gameobject, Building building)
	{
		this._building = building;
		this._owner_gameobject = owner_gameobject;
	}

	public void Enter()
	{
		_building.StartUse();
	}

	public IState Execute()
	{
		t+=Time.deltaTime;
		
		if (t>=1f)
		{
			_building.Use();
			t=0;
		}


        return null;
	}

	public void Exit()
	{
		_building.StopUse();
	}

    public eStateType GetStateType()
    {
		if (_building.GetType() == typeof(Cart))
		{
			return eStateType.carting;
		}
        return eStateType.using_building;
    }
}
