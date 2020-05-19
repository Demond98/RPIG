


using RPIG.Engine;
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
					new ButtonFunc("To center", state => (locations["center"], state), null, s => true))
				);
		
		return locations;
	}
}

