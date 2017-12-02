using UnityEngine;

namespace FSM.Test
{
	public sealed class VisitBankAndDepositGold :  FSMState<Miner> {
		
		static readonly VisitBankAndDepositGold instance = new VisitBankAndDepositGold();
		public static VisitBankAndDepositGold Instance {
			get {
				return instance;
			}
		}
		static VisitBankAndDepositGold() { }
		private VisitBankAndDepositGold() { }
		
			
		public override void Enter (Miner m) {
			if (m._location != Locations.bank) {
				Debug.Log("Entering the bank...");
				m.ChangeLocation(Locations.bank);
			}
		}
		
		public override void Execute (Miner m) {
			Debug.Log("Feeding The System with MY gold... " + m.money_in_bank);
			m.AddToMoneyInBank(m.gold_carried);	
			m.ChangeState(EnterMineAndDigForNugget.Instance);
		}
		
		public override void Exit(Miner m) {
			Debug.Log("Leaving the bank...");
		}
	}
}
