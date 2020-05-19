﻿using Bridge;
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
		public static Game Game;
		public static HtmlWindow Window;

		//TODO добавить загрузку из файла
		public static Dictionary<string, GameLocation> GameLocations
			= new Dictionary<string, GameLocation>();

		public static void Main()
		{
			GameLocations.Add("left", new GameLocation($@"<h1>Left</h1><img src=""left.webp"" width=""189"" height=""255""/>",
				new ButtonFunc(
					"To center",
					state => new State() { Location = GameLocations["center"] },
					null,
					s => true),
				new ButtonFunc(
					"To right",
					state => new State() { Location = GameLocations["right"] },
					null,
					s => false)
			));

			GameLocations.Add("right", new GameLocation($@"<h1>Right</h1><img src=""right.webp"" width=""189"" height=""255""/>",
				new ButtonFunc("To center", state => new State() { Location = GameLocations["center"] }, null, s => true)
			));

			GameLocations.Add("center", new GameLocation($@"<h1>Center</h1><img src=""center.webp"" width=""189"" height=""255""/>",
				new ButtonFunc("To the left", state => new State() { Location = GameLocations["left"] }, null, s => true),
				new ButtonFunc("To the right", state => new State() { Location = GameLocations["right"] }, null, s => true)
			));

			Game = new Game()
			{
				CurrentState = new State()
				{
					Location = GameLocations["center"]
				}
			};
			Window = new HtmlWindow(Game);
		}
	}
}