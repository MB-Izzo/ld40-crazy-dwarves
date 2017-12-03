using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStateType
{
    none = 0,
    moving,
    using_building,
    idle,
    carting
}

public class StateMachine
{
    private IState _current_state;

    public void Update()
    {
        if (_current_state != null)
        {
            IState new_state = _current_state.Execute();
            if ( new_state != null )
            {
                OverrideCurrentState(new_state);
            }
        }
    }

    public void OverrideCurrentState(IState new_state)
    {
        if ( _current_state != null )
        {
            _current_state.Exit();
        }
        _current_state = new_state;
        if (_current_state != null)
        {
            _current_state.Enter();
        }
    }

    public eStateType GetCurrentStateType()
    {
        return _current_state == null ? eStateType.none : _current_state.GetStateType();
    }
}

// NOTNEEDED: new implementation above.
//public class StateMachine : MonoBehaviour {
	
//	private IState _current_state;
//	private IState _previous_text;

//	public void ChangeState(IState new_state)
//	{
//		if (this._current_state != null)
//		{
//			this._current_state.Exit();
//		}

//		this._previous_text = this._current_state;
//		this._current_state = new_state;
//		this._current_state.Enter();
//	}

//	public void ExecuteStateUpdate()
//	{
//		IState running_state = this._current_state;
//		if (running_state != null)
//		{
//			running_state.Execute();
//		}
//	}

//	public void SwitchToPreviousState()
//	{
//		this._current_state.Exit();
//		this._current_state = this._previous_text;
//		this._current_state.Enter();
//	}
//}
