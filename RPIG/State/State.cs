using RPIG.States.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPIG.States;
using RPIG.Engine;

namespace RPIG.States
{
	public class State
	{
		public GameLocation Location;
		public Player Player;
		
		public State()
		{

		}

		public State(State state)
		{
			Location = state.Location;
			Player = state.Player.Copy();
		}

		public State Copy()
		{
			return new State(this);
		}
	}
}