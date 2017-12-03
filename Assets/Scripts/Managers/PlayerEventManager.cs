using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEventManager : MonoBehaviour {

	private static PlayerEventManager _instance;
	public static PlayerEventManager Instance { get { return _instance; } }

	private List<Building> buildings { get { return BuildingManager.Instance.buildings; } }

	public delegate void EventOnDwarfNeeded(Building new_building);
    public EventOnDwarfNeeded OnDwarfNeeded;

    public delegate void EventOnSellAvailable(Building new_building);
    public EventOnSellAvailable OnSellAvalaible;

	private Building cart { get { return BuildingManager.Instance._cart; } }

	public Button call_for_work_brewery;
	public Button call_for_work_kitchen;
	public Button call_for_sell_btn;

	private void Awake() {
		if (_instance != this && _instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		call_for_work_brewery.onClick.AddListener(CallForBrewery);
		call_for_work_kitchen.onClick.AddListener(CallForKitchen);
		call_for_sell_btn.onClick.AddListener(CallForSell);
	}

	private void CallForBrewery()
    {
        foreach(Building b in buildings)
        {
			if (b is BeerMaker)
			{
				if (b.is_being_used == false)
				{
					if (OnDwarfNeeded!=null)
					{
						OnDwarfNeeded(b);
					}
				}
			}
		}
    }

	private void CallForKitchen()
    {
        foreach(Building b in buildings)
        {
			if (b is Kitchen)
			{
				if (b.is_being_used == false)
				{
					if (OnDwarfNeeded!=null)
					{
						OnDwarfNeeded(b);
					}
				}
			}
		}
    }

    private void CallForSell()
    {

        if (OnSellAvalaible != null)
        {
            OnSellAvalaible(cart);
        }       
    }

}


