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
	public static class App
	{
		public const string GAME_STATE_PATH = "RPIG.App.Game.CurrentState";

		public static Game Game;
		public static HtmlWindow Window;
		public static Dictionary<string, GameLocation> GameLocations
			= new Dictionary<string, GameLocation>();

		public static void Main()
		{
			GameLocations = LocationLoader.Load();

			Game = new Game(GameLocations["Center"]);
			Window = new HtmlWindow();
			Window.Field.DrawLocation(Game.CurrentState);
		}

		public static void ChangeState(State newState)
		{
			Game.ChangeState(newState);
			Window.Field.DrawLocation(Game.CurrentState);
		}

		internal static void HistoryBackward(MouseEvent<HTMLButtonElement> arg)
		{
			Game.HistoryBackward(arg);
			Window.DrawLocation(Game.CurrentState);
		}

		internal static void HistoryForward(MouseEvent<HTMLButtonElement> arg)
		{
			Game.HistoryForward(arg);
			Window.DrawLocation(Game.CurrentState);
		}

		public static T CallFunction<T>(string functionName)
		{
			return Script.Eval<T>($"{functionName}({GAME_STATE_PATH})");
		}
	}
}