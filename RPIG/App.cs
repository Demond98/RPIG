using Bridge;
using Newtonsoft.Json;
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

		//TODO вынести в класс
		public static Dictionary<string, GameLocation> GameLocations
			= new Dictionary<string, GameLocation>();

		public static void Main()
		{
			GameLocations.Add("left", new GameLocation($@"<h1>Left</h1><img src=""left.webp"" width=""189"" height=""255""/>", 
				new TransitionFunc("To center", state => (GameLocations["center"], state), null, s => true),
				new TransitionFunc("To right", state => (GameLocations["right"], state), null, s => false)
			));
			
			GameLocations.Add("right", new GameLocation($@"<h1>Right</h1><img src=""right.webp"" width=""189"" height=""255""/>", 
				new TransitionFunc("To center", state => (GameLocations["center"], state), null, s => true)
			));

			GameLocations.Add("center", new GameLocation($@"<h1>Center</h1><img src=""center.webp"" width=""189"" height=""255""/>", 
				new TransitionFunc("To the left", state => (GameLocations["left"], state), null, s => true),
				new TransitionFunc("To the right", state => (GameLocations["right"], state), null, s => true)
			));

			Game = new Game()
			{
				CurrentLocation = GameLocations["center"]
			};
			Window = new HtmlWindow(Game);
		}
	}
}

/*
var button = new HTMLButtonElement()
{
	TextContent = "Click me!",
	ClassName = "btn btn-primary"
};

var count = 1;

button.OnClick += (e) =>
{
	button.TextContent = $"Clicked {count} times";

	if (count == 1)
	{
		var msg = "Welcome to Bridge.NET";

		Console.WriteLine(msg);
	}

	count++;
};

Document.Body.AppendChild(button);
*/
