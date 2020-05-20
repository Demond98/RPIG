using RPIG.Engine;
using RPIG.States;
using System.Collections.Generic;

public static partial class LocationLoader
{
	public static Dictionary<string, GameLocation> Load() 
	{
		var locations = new Dictionary<string, GameLocation>();

		locations.Add(
			"start",
			new GameLocation (
				@"<h1>Center</h1>",
				@"h1 {
}",
				new ButtonFunc("To left", state => new State(){ Location = locations["left"] }, null, s => true), new ButtonFunc("To right", state => new State(){ Location = locations["right"] }, null, s => true))
			);
		locations.Add(
			"left",
			new GameLocation (
				@"<h1>Left</h1>",
				@"h1 {
}",
				new ButtonFunc("To center", state => new State(){ Location = locations["start"] }, null, s => true), new ButtonFunc("To right", state => new State(){ Location = locations["right"] }, null, s => false))
			);
		locations.Add(
			"right",
			new GameLocation (
				@"<h1>Right</h1>",
				@"h1 {
}",
				new ButtonFunc("To center", state => new State(){ Location = locations["start"] }, null, s => true), new ButtonFunc("To left", state => new State(){ Location = locations["left"] }, null, s => false))
			);
		
		return locations;
	}
}

