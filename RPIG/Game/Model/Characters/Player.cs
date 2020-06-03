using RPIG.Model.Characters;
using System.Collections.Generic;

namespace RPIG.Model.Characters
{
	public class Player
	{
		public int Money;
		public List<Cow> Cows;

		public Player()
		{
			Cows = new List<Cow>();
		}

		public Player(Player player)
		{
			Money = player.Money;
			Cows = player.Cows;
		}

		public Player Copy()
		{
			return new Player(this);
		}
	}
}