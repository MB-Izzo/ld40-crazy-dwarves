using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CD.FSM
{
	public class FSMState {

		private List<FSMAction> _actions;
		private string name;
		private FSM owner;
		private Dictionary<string, FSMState> transition_map;

		// Initialize a new instance.
		public FSMState (string name, FSM owner)
		{
			this.name = name;
			this.owner = owner;
			this.transition_map = new Dictionary<string, FSMState>();
			this._actions = new List<FSMAction>();

		}

		// Adds the transition.
		public void AddTransition(string id, FSMState destination_state)
		{
			if (transition_map.ContainsKey(id))
			{
				Debug.LogError(string.Format("State {0} already contains transitions for {1}", this.name, id));
				return;
			}

			transition_map[id] = destination_state;
		}

		// Get the transition
		public FSMState GetTransition(string event_id)
		{
			if (transition_map.ContainsKey(event_id))
			{
				return transition_map[event_id];
			}
			return null;
		}

		// Adds the action
		public void AddAction(FSMAction action)
		{
			if (_actions.Contains(action))
			{
				Debug.LogWarning("This state already contains " + action);
				return;
			}
			if (action.GetOwner() != this)
			{
				Debug.LogWarning("This state doesn't own " + action);
			}

			_actions.Add(action);
		}
		
		// Gets the actions of this state.
		public IEnumerable<FSMAction> GetActions()
		{
			return _actions;
		}

		public void SendEvent(string event_id)
		{
			this.owner.SendEvent(event_id);
		}


	
	}
}


