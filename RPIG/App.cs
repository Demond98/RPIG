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
		public const string GAME_CURRENTSTATE = "RPIG.App.Game.CurrentState";
		
		public static Game Game;
		public static HtmlWindow Window;

		public static Dictionary<string, GameLocation> GameLocations
			= new Dictionary<string, GameLocation>();

		public static void Main()
		{
			GameLocations = LocationLoader.Load();
			Game = new Game(GameLocations["start"]);

			Window = new HtmlWindow(Game);
		}

		public static void ChangeState(string transitFunctionBody, string nextStateName)
		{
			var funcionBody = $"{transitFunctionBody}({GAME_CURRENTSTATE}, {nextStateName})";
			Game.CurrentState = Script.Eval<State>(funcionBody);
			Game.SaveState();
			Window.Field.DrawLocation(Game.CurrentState);
		}

		//public static State ChangeState(State state, string location)
		//{
		//	state.Location = GameLocations[location];
		//	state.Player.Money++;

		//	return state;
		//}
	}
}