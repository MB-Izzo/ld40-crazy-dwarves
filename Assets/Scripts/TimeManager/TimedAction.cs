using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class TimedAction
{
	private DateTime _time_started;
	private DateTime _last_date;
	private float _action_ratio;
	private double _time_progress;
	private double _time_remaining;

	[SerializeField]
	private float _duration;
	[SerializeField]
	private long _seria_time_started;
	[SerializeField]
	private long _seria_last_date;


    // public accessors
	public DateTime time_started { get { return _time_started; } }
	public float duration { get { return _duration; } }
	public float ratio { get { return _action_ratio; } }
	public double time_remaining { get { return _time_remaining; } }

	public TimedAction(float duration, DateTime date)
	{
		_time_started = date;
		_last_date = _time_started;
		_duration = duration;
		_action_ratio = 0.0f;
		_time_remaining = duration;
	}

	public virtual void Update(DateTime new_date)
	{
		double delta = MsElapsed(new_date, _last_date);
		_time_progress += delta / 1000f;
		_time_remaining -= delta / 1000f;
		_action_ratio = Mathf.Min((float)_time_progress / _duration, 1f);
		_last_date = new_date;
	}

	private double MsElapsed(DateTime a, DateTime b)
	{
		return a.Subtract(b).TotalMilliseconds;
	}

	public string SerializeToJSON()
	{
		_seria_time_started = this.time_started.ToFileTimeUtc();
		_seria_last_date = this._last_date.ToFileTimeUtc();
		return JsonUtility.ToJson(this, true); // TODO: Display the content of the string.
	}

	public void DeserializeDate()
	{
		_time_started = DateTime.FromFileTimeUtc (_seria_time_started);
		_last_date = DateTime.FromFileTimeUtc (_seria_last_date);
	}

	public bool IsFinished()
	{
		return _action_ratio == 1;
	}
}

public enum ActionType {
	MOVE_TO,
	ATTACK
}