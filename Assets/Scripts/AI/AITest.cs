using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CD.FSM;

public class AITest : MonoBehaviour {

	private FSM _fsm;
	private FSMState _patrol_state;
	private FSMState _idle_state;
	private TextAction _patrol_action;
	private TextAction _idle_action;

	private void Start() {
		_fsm = new FSM("AITest FSM");
		_idle_state = _fsm.AddState("idle_state");
		_patrol_state = _fsm.AddState("patrol_state");
		_patrol_action = new TextAction(_patrol_state);
		_idle_action = new TextAction(_idle_state);
		
		// Add actions to the state and add state to its transition map.
		_patrol_state.AddAction(_patrol_action);
		_idle_state.AddAction(_idle_action);

		_patrol_state.AddTransition("to_idle", _idle_state);
		_idle_state.AddTransition("to_patrol", _patrol_state);

		_patrol_action.Init("AI on patrol", 3.0f, "to_idle");
		_patrol_action.Init("AI on Idle", 2.0f, "to_patrol");

		_fsm.Start("idle_state");
	}
	
	private void Update() {
		_fsm.Update();
	}
}
