using RPIG.Engine;
using RPIG.Model.Characters;

namespace RPIG.Model
{
	public class State
	{
		public GameLocation Location;
		public Player Player;

		public State()
		{
		}

		public State(State state)
		{
			Location = state.Location;
			Player = state.Player.Copy();
		}

		public State Copy()
		{
			return new State(this);
		}
	}
}