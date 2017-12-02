using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CD.FSM {

	// Main engine of FSM.
	public class FSM {

		private readonly string _name;
		public string Name { get { return _name; } }

		private FSMState current_state;
		private readonly Dictionary<string, FSMState> state_map;

		// Gives the FSM a unique ID, constructor.
		public FSM(string name)
		{
			this._name = name;
			this.current_state = null;
			state_map = new Dictionary<string, FSMState>();
		}

		// Indicates starting state of the object that has an FSM.
		public void Start(string stateName) {
			if (!state_map.ContainsKey(stateName))
			{
				Debug.LogWarning("The FSM doesn't contain: " + stateName);
				return;
			}

			ChangeToState(state_map[stateName]);
		}

		// Change the state of the object, also calls the exit state before changing state.
		public void ChangeToState(FSMState state)
		{
			if (this.current_state != null)
			{
				ExitState(this.current_state);
			}

			this.current_state = state;
			EnterState(this.current_state);
		}

		// Change the state of the object. Do not call this to change state.
		public void EnterState(FSMState state)
		{
			ProcessStateAction(state, delegate(FSMAction action) {
				action.OnEnter();
			});

		}

		// Is called before changing state.
		public void ExitState(FSMState state)
		{
			FSMState current_state_on_invoke = this.current_state;
			ProcessStateAction(state, delegate(FSMAction action){
				if (this.current_state != current_state_on_invoke)
				{
					Debug.LogError("State cannot be changed on exit of the specified state.");
				}

				action.OnExit();
			});
		}

		// Call under a monobehavior.
		public void Update()
		{
			if (this.current_state == null)
			{
				return;
			}

			ProcessStateAction(this.current_state, delegate(FSMAction action)
			{
				action.OnUpdate();
			});
		}

		// Handles the events that is bound to a state and changes the state.
		public void SendEvent(string event_id)
		{
			FSMState transition_state = ResolveTranstion(event_id);
			if (transition_state == null)
			{
				Debug.LogWarning("The current state has no transition for event " + event_id);
			}
			else
			{
				ChangeToState(transition_state);
			}
		}

		private FSMState ResolveTranstion(string event_id)
		{
			FSMState transition_state = this.current_state.GetTransition(event_id);
			if (transition_state == null)
			{
				return null;
			}
			else
			{
				return transition_state;
			}
		}

		public FSMState AddState(string name)
		{
			if (state_map.ContainsKey(name))
			{
				Debug.LogWarning("The FSM already contains: " + name);
				return null;
			}

			FSMState new_state = new FSMState(name, this);
			state_map[name] = new_state;
			return new_state;
		}

		private delegate void StateActionProcessor(FSMAction action);

		// This gets all the actions that is inside the state and loop them.
		private void ProcessStateAction(FSMState state, StateActionProcessor action_processor)
		{
			FSMState current_state_on_invoke = this.current_state;
			IEnumerable<FSMAction> actions = state.GetActions();

			foreach(FSMAction action in actions)
			{
				if (this.current_state != current_state_on_invoke)
				{
					break;
				}

				action_processor(action);
			}
		}
	}

}

