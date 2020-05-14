using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;
using RPIG.States;

namespace RPIG.Engine
{
	public class Game
	{
		public Stack<(GameLocation location, State state)> StatesStack;
		public GameLocation CurrentLocation;
		public State CurrentState;
		
		//практически везде стейт с локацией передаётся в свзяке
		//мб стоит их в отдельный класс добавить или в стейт запихнуть
		public event Action<GameLocation, State> LocationChanged;

		public void PushButtonHandler<T>(MouseEvent<T> e) where T : HTMLElement
			=> PushButton(e.CurrentTarget.TextContent);

		private void PushButton(string actionText)
		{
			(CurrentLocation, CurrentState) = CurrentLocation
				.TransitionFuncs
				.First(a => a.Text == actionText)
				.Transit(CurrentState);

			LocationChanged?.Invoke(CurrentLocation, CurrentState);
		}
	}
}