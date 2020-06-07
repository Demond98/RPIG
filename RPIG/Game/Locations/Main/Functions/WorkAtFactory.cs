using RPIG.Model;

namespace RPIG
{
	public static class WorkAtFactory
	{
		public static State Transit(State state)
		{
			state.Player.Money++;

			return state;
		}

		public static bool IsHide(State state)
			=> GameLogic.AllwaysFalse(state);

		public static bool IsActive(State state)
			=> GameLogic.AllwaysTrue(state);
	}
}