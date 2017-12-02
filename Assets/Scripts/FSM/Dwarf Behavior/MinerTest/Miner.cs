using UnityEngine;

namespace FSM.Test
{
	public enum Locations { goldmine, bar, bank, home };

	public class Miner : MonoBehaviour {
		
		private FiniteStateMachine<Miner> FSM;
		
		public Locations _location = Locations.goldmine;
		public int gold_carried = 0;
		public int money_in_bank  = 0;
		private int _thirst = 0;
		private int  _fatigue = 0;
		
		public void AddToGoldCarried(int amount) {
			gold_carried += amount;
		}
		
		public void AddToMoneyInBank(int amount ) {
			money_in_bank += amount;
			gold_carried = 0;
		}
		
		public bool RichEnough() {
			return false;
		}
		
		public bool PocketsFull() {
			bool full = gold_carried ==  2 ? true : false;
			return full;
		}
		
		public bool _thirsty() {
			bool _thirsty = _thirst == 10 ? true : false;
			return _thirsty;
		}
		
		public void IncreaseFatigue() {
			_fatigue++;
		}
		
		public void ChangeState(FSMState<Miner> e) {
			FSM.ChangeState(e);		
		}
		
		public void Awake() {
			Debug.Log("Miner awakes...");
			FSM = new FiniteStateMachine<Miner>();
			FSM.Configure(this, EnterMineAndDigForNugget.Instance);
		}
	
		public void Update() {
			_thirst++;
			FSM.Update();
		}
		
		public void ChangeLocation(Locations l) {
			_location = l;
		}
	}
}



