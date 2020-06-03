using RPIG.Model;
using RPIG.Model.Characters;
using System.Collections.Generic;

namespace RPIG.Engine
{
	public class GameEngine
	{
		public State CurrentState { get; private set; }
		private State StateOnLoad;
		private Stack<State> StatesStack;
		private Stack<State> StatesStackInFuture;

		public GameEngine(GameLocation startLocation)
		{
			StatesStack = new Stack<State>();
			StatesStackInFuture = new Stack<State>();
			CurrentState = new State()
			{
				Location = startLocation,
				Player = new Player()
			};
			StateOnLoad = CurrentState.Copy();
		}

		public bool HistoryBackward()
			=> HistoryMove(StatesStackInFuture, StatesStack);

		public bool HistoryForward()
			=> HistoryMove(StatesStack, StatesStackInFuture);

		private bool HistoryMove(Stack<State> pushStack, Stack<State> popStack)
		{
			if (popStack.Count < 1)
				return false;

			pushStack.Push(StateOnLoad.Copy());
			StateOnLoad = popStack.Pop();
			CurrentState = StateOnLoad.Copy();

			return true;
		}

		public void ChangeState(State newState)
		{
			CurrentState = newState.Copy();
			StatesStack.Push(StateOnLoad.Copy());
			StatesStackInFuture.Clear();
			StateOnLoad = CurrentState.Copy();
		}
	}
}