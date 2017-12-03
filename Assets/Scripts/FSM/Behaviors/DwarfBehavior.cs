using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfBehavior : MonoBehaviour
{
	private StateMachine _fsm;

    public eStateType current_state_type { get { return _fsm.GetCurrentStateType(); } }

    private bool on_beer_maker;

    private Building save_building;

    private Job _job;

    private static int nbr_instances;
    private int id;

	// Use this for initialization
	void Start () {
        _fsm = new StateMachine();
        PlayerEventManager.Instance.OnDwarfNeeded += OnNeeded;
        PlayerEventManager.Instance.OnSellAvalaible += OnSell;
        nbr_instances++;
        id = nbr_instances;
        if (id == 1)
        {
            _job = Job.seller;
        }
        else
        {
            _job = Job.producer;
        }
        

    }

    private void OnDestroy()
    {
        PlayerEventManager.Instance.OnDwarfNeeded -= OnNeeded;
        PlayerEventManager.Instance.OnSellAvalaible -= OnSell;

    }

    /// <summary>
    /// Raised by BuildingManager.OnBuildingCreated
    /// </summary>
    /// <seealso cref="BuildingManager"/>
    /// <seealso cref="Building"/>
    /// <param name="new_building">Newly created building</param>
    private void OnNeeded(Building new_building)
    {

        if ( new_building != null && new_building.is_being_used == false && current_state_type != eStateType.using_building)
        {
            this._fsm.OverrideCurrentState(new GoTo(gameObject, new_building.transform.position, 3f, new_building));

        }
    }

    private void OnSell(Building new_building)
    {
        if (new_building != null && new_building.is_being_used == false && current_state_type != eStateType.carting && _job == Job.seller)
        {
            this._fsm.OverrideCurrentState(new GoTo(gameObject, new_building.transform.position, 3f, new_building));

        }
    }

    // Update is called once per frame
    void Update () {
		this._fsm.Update();
        Debug.Log(_job);
        Debug.Log(id); 
	}

}

public enum Job {
    seller,
    producer
}