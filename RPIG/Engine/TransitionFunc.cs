using RPIG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine
{
	public class TransitionFunc
	{
		public readonly string Text;
		public readonly Func<State, (GameLocation location, State state)> Transit;
		public readonly Func<State, bool> IsHide;
		public readonly Func<State, bool> IsActive;

		public TransitionFunc(string text, Func<State, (GameLocation, State)> transit, Func<State, bool> isHide, Func<State, bool> isActive)
		{
			Text = text;
			Transit = transit;
			IsHide = isHide;
			IsActive = isActive;
		}
	}
}