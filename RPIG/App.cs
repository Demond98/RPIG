using Bridge;
using System;
using Bridge.Html5;
using System.Collections.Generic;
using System.Linq;

using RPIG.Engine;
using RPIG.States;
using RPIG.View;
using System.ComponentModel.DataAnnotations;

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

			Game = new Game(GameLocations[LocationName.Center]);
			Window = new HtmlWindow();
			Window.Field.DrawLocation(Game.CurrentState);
		}

		public static void ChangeState(State newState)
		{
			Game.ChangeState(newState);
			Window.Field.DrawLocation(Game.CurrentState);
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

		public static T CallFunction<T>(string functionName)
		{
			return Script.Eval<T>($"{functionName}({GAME_STATE_PATH})");
		}
	}
}