using RPIG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.GameLogic
{
	public static class GameLogic
	{
		public static State ChangeStateFirst(State state, string location)
		{
			state.Location = App.GameLocations[location];
			state.Player.Money++;

			return state;
		}

		public static bool FOO(State state)
		{
			return true;
		}
	}
}
