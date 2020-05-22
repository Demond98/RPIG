using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.States.Characters
{
	public class Player
	{
		public int Money;

		public Player()
		{

		}

		public Player(Player player)
		{
			Money = player.Money;
		}

		public Player Copy()
		{
			return new Player(this);
		}
	}
}
