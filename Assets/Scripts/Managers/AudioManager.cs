﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}
	
	public void Play(string name)
	{
		foreach(Sound s in sounds)
		{
			if (s.name == name)
			{
				s.source.Play();
			}
		}
	}
}
