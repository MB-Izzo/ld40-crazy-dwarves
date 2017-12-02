﻿using UnityEngine;

namespace FSM.Test
{
	public sealed class EnterMineAndDigForNugget :  FSMState<Miner> {
		
		static readonly EnterMineAndDigForNugget instance = new EnterMineAndDigForNugget();
		public static EnterMineAndDigForNugget Instance {
			get {
				return instance;
			}
		}
		static EnterMineAndDigForNugget() { }
		private EnterMineAndDigForNugget() { }
		
			
		public override void Enter (Miner m) {
			if (m._location != Locations.goldmine) {
				Debug.Log("Entering the mine...");
				m.ChangeLocation(Locations.goldmine);
			}
		}
		
		public override void Execute (Miner m) {		
			m.AddToGoldCarried(1);
			Debug.Log("Picking ap nugget and that's..." + m.gold_carried);
			m.IncreaseFatigue();		
			if (m.PocketsFull())
				m.ChangeState(VisitBankAndDepositGold.Instance);
		}
		
		public override void Exit(Miner m) {
			Debug.Log("Leaving the mine with my pockets full...");
		}
	}
}
