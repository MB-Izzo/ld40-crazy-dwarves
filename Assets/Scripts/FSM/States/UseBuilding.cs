using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBuilding : IState {

	public UseBuilding()
	{

	}

	public void Enter()
	{

	}

	public IState Execute()
	{
        return null;
	}

	public void Exit()
	{
		
	}

    public eStateType GetStateType()
    {
        return eStateType.using_building;
    }
}
