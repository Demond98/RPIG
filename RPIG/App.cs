using Bridge;
using Bridge.Html5;
using RPIG.Engine;
using RPIG.Model;
using RPIG.View;
using System;
using System.Collections.Generic;

namespace RPIG
{
	public static partial class App
	{
		public const string GAME_STATE_PATH = "RPIG.App.Game.CurrentState";

		public static Game Game;
		public static HtmlWindow Window;
		public static Dictionary<LocationName, GameLocation> GameLocations;

		public static void Main()
		{
			GameLocations = LocationLoader.Load();

			Game = new Game(GameLocations[LocationName.Main]);
			Window = new HtmlWindow();
			Window.DrawLocation(Game.CurrentState);
		}

		public static void ExecuteChangeStateLogic(string className)
		{
			var newState = HtmlAttributesLogic.CallFunction<State>($"{className}.Transit");
			Game.ChangeState(newState);
			Window.DrawLocation(Game.CurrentState);
		}

		public static void HistoryBackward(MouseEvent<HTMLButtonElement> _)
			=> HistoryMove(Game.HistoryBackward);

		public static void HistoryForward(MouseEvent<HTMLButtonElement> _)
			=> HistoryMove(Game.HistoryForward);

		public static void HistoryMove(Func<bool> historyMove)
		{
			var needDraw = historyMove();
			if (needDraw)
				Window.DrawLocation(Game.CurrentState);
		}
	}
}