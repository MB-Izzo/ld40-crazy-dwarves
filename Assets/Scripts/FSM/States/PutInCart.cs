using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInCart : IState {

	private float t;
	private GameObject _owner_gameobject;
	private Building _building;

	public PutInCart(GameObject owner_gameobject, Building b)
	{
		this._owner_gameobject = owner_gameobject;
		this._building = b;
	}

	public void Enter()
	{
		_building.StartUse();
	}

	public IState Execute()
	{
		t+=Time.deltaTime;
		if (t >= 1)
		{
			_building.Use();
			t=0;
		}
		if (ResourcesManager.Instance.CanSell() == false)
		{
			return new Idle(_owner_gameobject, new Vector3(0, 0.5f, 0), 3f);
		}
		return null;
	}

	public void Exit()
	{
		_building.StopUse();
	}

	public eStateType GetStateType()
	{
		return eStateType.carting;
	}
}
