using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimedActionFactory {

	public static TimedAction CreateTimedAction(float duration, DateTime date)
	{
		TimedAction new_action = new TimedAction(duration, date);
		TimeManager.RegisterTimedAction (new_action);
		return new_action;
	}

	public static TimedAction CreateTimedAction(TimedAction existing_action)
	{
		TimedAction new_action = existing_action;
		TimeManager.RegisterTimedAction (new_action);
		return new_action;
	}

	public static TimedAction CreateTimedAction(string timed_action_json)
	{
		TimedAction new_action = JsonUtility.FromJson<TimedAction> (timed_action_json); // ERROR HERE
		new_action.DeserializeDate ();
		CreateTimedAction (new_action);
		return new_action;
	}
}