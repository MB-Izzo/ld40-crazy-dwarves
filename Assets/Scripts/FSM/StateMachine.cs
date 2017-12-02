using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
	
	private IState _current_state;
	private IState _previous_text;

	public void ChangeState(IState new_state)
	{
		if (this._current_state != null)
		{
			this._current_state.Exit();
		}

		this._previous_text = this._current_state;
		this._current_state = new_state;
		this._current_state.Enter();
	}

	public void ExecuteStateUpdate()
	{
		IState running_state = this._current_state;
		if (running_state != null)
		{
			running_state.Execute();
		}
	}

	public void SwitchToPreviousState()
	{
		this._current_state.Exit();
		this._current_state = this._previous_text;
		this._current_state.Enter();
	}
}
