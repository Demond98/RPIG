using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPIG.States;

namespace RPIG.Engine
{
	public class Game
	{
		public Node CurrentNode;
		public State CurrentState;

		public void PushButton(string actionText)
		{
			CurrentNode = CurrentNode
				.TransitionFuncs
				.First(a => a.Text == actionText)
				.Transit(CurrentState);
		}
	}
}
