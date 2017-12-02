using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBeerMaker : FSMState<Dwarf> {

	static readonly GoToBeerMaker instance = new GoToBeerMaker();
	public static GoToBeerMaker Instance {
		get {
			return instance;
		}
	}
	static GoToBeerMaker() { }
	private GoToBeerMaker() { }
	
		
	public override void Enter (Dwarf m) {
		// GO TO BEER MAKER.
	}
	
	public override void Execute (Dwarf m) {
		// USE BEER MAKER.
	}
	
	public override void Exit(Dwarf m) {
		// LEAVE BEER MAKER.
	}
}
