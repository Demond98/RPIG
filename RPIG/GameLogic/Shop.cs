using RPIG.Model;
using RPIG.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.GameLogic
{
	public static partial class GameLogic
	{
		public static bool IsCanByCow(State state)
			=> state.Player.Money >= Cow.Price;

		public static State AddCow(State state)
		{
			state.Player.Money -= Cow.Price;
			state.Player.Cows.Add(new Cow());
			
			return state;
		}

		public static State GoToMain(State state)
			=> ChangeLocation(state, App.LocationName.Main);
	}
}
