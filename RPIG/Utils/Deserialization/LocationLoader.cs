
using RPIG.Engine;
using RPIG.States;
using System.Collections.Generic;

public static partial class LocationLoader
{
	public static Dictionary<string, GameLocation> Load() 
	{
		var locations = new Dictionary<string, GameLocation>();

					var locationKey = "Location1";
			locations.Add
				(
					locationKey,
					new GameLocation (
					@"<h1></h1>
",
					@"h1 {
}",
					new ButtonFunc("To center", state => new State(){ Location = locations["Location1"] }, null, s => true))
				);
		
		return locations;
	}
}

