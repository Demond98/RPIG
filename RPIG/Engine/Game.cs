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
		public Stack<(Location location, State state)> StatesStack;
		public Location CurrentLocation;
		public State CurrentState;

		public void PushButtonHandler(MouseEvent<HTMLDivElement> e)
			=> PushButton(e.CurrentTarget.TextContent);

		private void PushButton(string actionText)
		{
			(CurrentLocation, CurrentState) = CurrentLocation
				.TransitionFuncs
				.First(a => a.Text == actionText)
				.Transit(CurrentState);
		}
	}
}
