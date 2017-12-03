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

		if (_building.GetType() == typeof(BeerMaker))
		{
			if (ResourcesManager.Instance.NeedBeer() == false)
			{
				return new Idle(_owner_gameobject, new Vector3(0, 0.5f, 0), 3f);
			}

		}
		
		if (_building.GetType() == typeof(Kitchen))
		{
			if (ResourcesManager.Instance.NeedMeat() == false)
			{
				return new Idle(_owner_gameobject, new Vector3(0, 0.5f, 0), 3f);
			}
		}

		if (_building.GetType() == typeof(Cart))
		{
			if (ResourcesManager.Instance.CanSell() == false)
			{
				return new Idle(_owner_gameobject, new Vector3(0, 0.5f, 0), 3f);
			}
		}
        return null;
	}

	public void Exit()
	{
		_building.StopUse();
	}

    public eStateType GetStateType()
    {
        return eStateType.using_building;
    }
}
