using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TimeManager {

	public static List<TimedAction> timed_actions = new List<TimedAction>();
	private static double secondsToAdd;


	public static TimedAction RegisterTimedAction(TimedAction timed_action)
	{
		timed_actions.Add (timed_action);
		return timed_action;
	}

	public static void Update()
	{
		foreach (TimedAction timedAction in timed_actions)
		{
			timedAction.Update (DateTime.Now.AddSeconds(secondsToAdd));
		}	
	}

	// Don't push your hacks
	public static void AddSecondsHack (double s)
	{
		secondsToAdd += s;
	}

}