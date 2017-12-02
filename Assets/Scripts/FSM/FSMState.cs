using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState<T> {

	abstract public void Enter(T entity);
	abstract public void Execute(T entity);
	abstract public void Exit(T entity);

}
