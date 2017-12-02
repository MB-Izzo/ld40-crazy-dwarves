using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfBehavior : MonoBehaviour {

	private Dwarf me;
	private StateMachine _fsm;
	private Vector3 brewery_pos;

	// Use this for initialization
	void Start () {
		_fsm = this.gameObject.AddComponent<StateMachine>();
		me = GetComponent<Dwarf>();
	}
	
	// Update is called once per frame
	void Update () {
		if (BuildingManager.Instance.buildings.Count >= 1) // if a brewy is built.
		{
			// GO TO IT.
			this._fsm.ChangeState(new GoTo(this.gameObject, this.transform.position, BuildingManager.Instance.buildings[0].transform.position, 3f));
			//problem is: change State is calling every frame, so the Enter() function of the state is called every frame instead of "changing state, then go execute it!"
			// Can't find a way to call change state only once. 
		}
		this._fsm.ExecuteStateUpdate();
	}
}
