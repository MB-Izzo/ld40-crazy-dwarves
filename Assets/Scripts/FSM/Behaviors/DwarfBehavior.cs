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

	// Use this for initialization
	void Start () {
        _fsm = new StateMachine();
        BuildingManager.Instance.OnDwarfNeeded += OnNeeded;

    }

    private void OnDestroy()
    {
        BuildingManager.Instance.OnDwarfNeeded -= OnNeeded;
    }

    /// <summary>
    /// Raised by BuildingManager.OnBuildingCreated
    /// </summary>
    /// <seealso cref="BuildingManager"/>
    /// <seealso cref="Building"/>
    /// <param name="new_building">Newly created building</param>
    private void OnNeeded(Building new_building)
    {
        if ( new_building != null && new_building.is_being_used == false && current_state_type != eStateType.using_building && ResourcesManager.Instance.NeedBeer())
        {
            this._fsm.OverrideCurrentState(new GoTo(gameObject, new_building.transform.position, 3f, new_building));
        }
    }

    // Update is called once per frame
    void Update () {
		this._fsm.Update();
        Debug.Log(current_state_type);
	}

}
