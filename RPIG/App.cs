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

		public static void Main()
		{
			var location = new GameLocation("<h1>Bibu dal</h1>", new TransitionFunc("lol", null, null, null));
			Game = new Game()
			{
				CurrentLocation = location
			};
			Window = new HtmlWindow();
			Window.Field.DrawLocation(Game.CurrentLocation, Game.CurrentState);
			Game.LocationChanged += Window.Field.DrawLocation;
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
