using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Bridge.Html5;
using RPIG.States;
using RPIG.States.Characters;

namespace RPIG.Engine
{
	public class Game
	{
		private Stack<State> StatesStack;
		private Stack<State> StatesStackInFuture;
		private State StateOnLoad;
		public State CurrentState { get; private set; }

		public Game(GameLocation startLocation)
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

		public void HistoryBackward(MouseEvent<HTMLButtonElement> mouseEvent)
			=> HistoryMove(StatesStackInFuture, StatesStack);

		public void HistoryForward(MouseEvent<HTMLButtonElement> mouseEvent)
			=> HistoryMove(StatesStack, StatesStackInFuture);

		private void HistoryMove(Stack<State> pushStack, Stack<State> popStack)
		{
			if (popStack.Count < 1)
				return;

			pushStack.Push(StateOnLoad.Copy());
			StateOnLoad = popStack.Pop();
			CurrentState = StateOnLoad.Copy();
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