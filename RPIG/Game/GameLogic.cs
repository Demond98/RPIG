using RPIG.Model;

namespace RPIG
{
	public static partial class GameLogic
	{
		public static State ChangeLocation(State state, App.LocationName locationName)
		{
			state.Location = App.GameLocations[locationName];

			return state;
		}

		public static bool AllwaysTrue(State _) => true;

		public static bool AllwaysFalse(State _) => false;
	}
}