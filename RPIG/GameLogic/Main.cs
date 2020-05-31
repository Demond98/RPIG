using RPIG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.GameLogic
{
	public static partial class GameLogic
	{
		public static State GoToShop(State state)
			=> ChangeLocation(state, App.LocationName.Shop);
	}
}
