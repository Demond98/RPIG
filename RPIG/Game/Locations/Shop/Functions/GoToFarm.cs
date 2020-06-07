using RPIG.Model;

namespace RPIG
{
	public static class GoToFarm
	{
		public static State Transit(State state)
			=> GameLogic.ChangeLocation(state, App.LocationName.Main);

		public static bool IsHide(State state)
			=> GameLogic.AllwaysFalse(state);

		public static bool IsActive(State state)
			=> GameLogic.AllwaysTrue(state);
	}
}