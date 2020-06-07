using RPIG.Model;
using RPIG.Model.Characters;

namespace RPIG
{
	public static class BuyCow
	{
		public static State Transit(State state)
		{
			state.Player.Money -= Cow.Price;
			state.Player.Cows.Add(new Cow());

			return state;
		}

		public static bool IsHide(State state)
			=> GameLogic.AllwaysFalse(state);

		public static bool IsActive(State state)
		{
			var gg = state.Player.Money >= Cow.Price;
			return state.Player.Money >= Cow.Price;
		}
	}
}