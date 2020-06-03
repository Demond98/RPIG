using RPIG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG
{
	public static class GoToShop
	{
		public static State Transit(State state)
			=> GameLogic.ChangeLocation(state, App.LocationName.Shop);

		public static bool IsHide(State state)
			=> GameLogic.AllwaysFalse(state);

		public static bool IsActive(State state)
			=> GameLogic.AllwaysTrue(state);
	}
}
