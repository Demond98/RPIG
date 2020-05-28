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
		public static State ChangeStateFirst(State state)
		{
			state.Location = App.GameLocations[App.LocationName.Left];
			state.Player.Money++;

			return state;
		}

		public static bool AllwaysTrue(State _) => true;
		public static bool AllwaysFalse(State _) => false;
	}
}
