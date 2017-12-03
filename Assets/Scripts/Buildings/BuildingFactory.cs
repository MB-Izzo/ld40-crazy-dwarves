using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingFactory {

	public static Building CreateBuilding(string name_building)
	{

		Building new_building = null;

		switch(name_building)
		{
			case "brewery":
				new_building = new BeerMaker();
				break;
			case "kitchen":
				new_building = new Building();
				break;
			default:
				break;
		}

		return new_building;
	}

}
