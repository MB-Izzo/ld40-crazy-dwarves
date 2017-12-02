using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CD.FSM;

public class TextAction : FSMAction {

	private string text_to_show;
	private float duration;
	private float cached_duration;
	private string finish_event;

	public TextAction(FSMState owner) : base (owner)
	{

	}

	public void Init(string text_to_show, float duration, string finish_event)
	{
		this.text_to_show = text_to_show;
		this.duration = duration;
		this.cached_duration = duration;
		this.finish_event = finish_event;
	}

	// Equivalent of start in a monobehavior.
	public override void OnEnter()
	{
		if (duration <= 0)
		{
			Finish();
			return;
		}
	}

	public override void OnUpdate()
	{
		duration -= Time.deltaTime;
		if (duration <=0)
		{
			Finish();
			return;
		}
		Debug.Log(text_to_show);
	}
	
	public override void OnExit()
	{

	}

	public void Finish()
	{
		if (!string.IsNullOrEmpty(finish_event))
		{
			GetOwner().SendEvent(finish_event);
		}

		duration = cached_duration;
	}

}
