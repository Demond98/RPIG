using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;
using RPIG.States;

namespace RPIG.Engine
{
	public class Game
	{
		public Stack<State> StatesStack;
		public State CurrentState;
		
		public event Action<State> LocationChanged;

		public void PushButtonHandler<T>(MouseEvent<T> e) where T : HTMLElement
			=> PushButton(e.CurrentTarget.TextContent);

		private void PushButton(string actionText)
		{
			CurrentState = CurrentState.Location
				.ButtonFuncs
				.First(a => a.Text == actionText)
				.Transit(CurrentState);

			LocationChanged?.Invoke(CurrentState);
		}
	}
}