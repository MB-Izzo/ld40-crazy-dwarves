using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : MonoBehaviour {

	private StateMachine _fsm = new StateMachine();

	// Use this for initialization
	void Start () {
		this._fsm.ChangeState(new GoTo(this.gameObject, this.transform.position, new Vector3(5, 0.5f, 0), 3f));
	}
	
	// Update is called once per frame
	void Update () {
		this._fsm.ExecuteStateUpdate();
	}
}
