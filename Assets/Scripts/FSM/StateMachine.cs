public class FiniteStateMachine <T>  {
	private T _owner;
	private FSMState<T> _current_state;
	private FSMState<T> _previous_state;
	private FSMState<T> _global_state;
	
	public void Awake()
	{		
		_current_state = null;
		_previous_state = null;
		_global_state = null;
	}
	
	public void Configure(T owner, FSMState<T> InitialState) {
		this._owner = owner;
		ChangeState(InitialState);
	}

	public void Update()
	{
		if (_global_state != null)  _global_state.Execute(_owner);
		if (_current_state != null) _current_state.Execute(_owner);
	}
 
	public void ChangeState(FSMState<T> new_state)
	{	
		_previous_state = _current_state;
 
		if (_current_state != null)
			_current_state.Exit(_owner);
 
		_current_state = new_state;
 
		if (_current_state != null)
			_current_state.Enter(_owner);
	}
 
	public void RevertToPreviousState()
	{
		if (_previous_state != null)
			ChangeState(_previous_state);
	}
};