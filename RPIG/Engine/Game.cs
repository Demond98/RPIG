using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;
using RPIG.States;
using RPIG.States.Characters;

namespace RPIG.Engine
{
	public class Game
	{
		public Stack<State> StatesStack;
		public Stack<State> StatesStackInFuture;
		public State CurrentState;
		public State StateOnLoad;

		public event Action<State> LocationChanged;

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
			LocationChanged?.Invoke(StateOnLoad);
		}

		public void PushButtonHandler<T>(MouseEvent<T> e) where T : HTMLElement
			=> PushButton(e.CurrentTarget.TextContent);

		private void PushButton(string actionText)
		{
			StatesStack.Push(StateOnLoad.Copy());
			StatesStackInFuture.Clear();

			StateOnLoad = CurrentState.Location
				.ButtonFuncs
				.First(a => a.Text == actionText)
				.Transit(CurrentState);
			CurrentState = StateOnLoad.Copy();
			
			LocationChanged?.Invoke(CurrentState);
		}
	}
}