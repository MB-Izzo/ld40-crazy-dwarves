using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Location {
	BeerMaker,
	Idle
}

public class Dwarf : MonoBehaviour {

	private FiniteStateMachine<Dwarf> FSM;

	public int gold_carrying = 0;
	private int _thirst = 0;
	private int  _fatigue = 0;

	public Location loc = Location.Idle;

	public void ChangeState(FSMState<Dwarf> e) {
		FSM.ChangeState(e);		
	}
	
	public void Awake() {
		Debug.Log("Miner awakes...");
		FSM = new FiniteStateMachine<Dwarf>();
		FSM.Configure(this, GoToBeerMaker.Instance);
	}
 
	public void Update() {
		_thirst++;
		FSM.Update();
	}
}
