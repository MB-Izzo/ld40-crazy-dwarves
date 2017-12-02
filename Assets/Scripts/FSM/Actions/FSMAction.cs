using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CD.FSM
{

	public class FSMAction {

		private readonly FSMState owner;

		public FSMAction(FSMState owner)
		{
			this.owner = owner;
		}

		public FSMState GetOwner()
		{
			return owner;
		}

		// Starts the action
		public virtual void OnEnter()
		{

		}

		// Updates the action.
		public virtual void OnUpdate()
		{

		}

		// Finishes the action.
		public virtual void OnExit()
		{

		}
		
	}

}

