using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour {

	private Animator _anim;

	// Use this for initialization
	void Start () {
		_anim = GetComponentInChildren<Animator>();
		 Destroy (this.gameObject, this._anim.GetCurrentAnimatorStateInfo(0).length); 
	}
	
	// Update is called once per frame
	void LateUpdate () {

	}
}
