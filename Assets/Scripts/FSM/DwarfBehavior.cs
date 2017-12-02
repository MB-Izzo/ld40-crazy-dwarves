using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfBehavior : MonoBehaviour
{
	private StateMachine _fsm;

    public eStateType current_state_type { get { return _fsm.GetCurrentStateType(); } }

	// Use this for initialization
	void Start () {
        _fsm = new StateMachine();
        BuildingManager.Instance.OnBuildingCreated += OnBuildingCreated;
    }

    private void OnDestroy()
    {
        BuildingManager.Instance.OnBuildingCreated -= OnBuildingCreated;
    }

    /// <summary>
    /// Raised by BuildingManager.OnBuildingCreated
    /// </summary>
    /// <seealso cref="BuildingManager"/>
    /// <seealso cref="Building"/>
    /// <param name="new_building">Newly created building</param>
    private void OnBuildingCreated(Building new_building)
    {
        if ( new_building != null && new_building.is_being_used == false && current_state_type != eStateType.using_building)
        {
            this._fsm.OverrideCurrentState(new GoTo(gameObject, new_building.transform.position, 3f));
        }
    }

    // Update is called once per frame
    void Update () {
		this._fsm.Update();
	}
}
