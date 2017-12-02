public interface IState
{
	void Enter();
	IState Execute();
	void Exit();
    eStateType GetStateType();
} 