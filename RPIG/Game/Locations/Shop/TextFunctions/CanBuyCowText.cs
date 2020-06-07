using RPIG.Model;
using RPIG.Model.Characters;

namespace RPIG
{
	public static class CanBuyCowText
	{
		public static string GetTextContent(State state)
		{
			var money = state.Player.Money;
			var cowPrice = Cow.Price;
			return money < cowPrice
				? $"Вам не хватает - {cowPrice - money}"
				: "Купите корову";
		}
	}
}