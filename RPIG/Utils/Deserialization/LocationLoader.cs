

//C:\Users\Дмитрий\source\repos\RPIG\RPIG.sln

using RPIG.Engine;
using System.Collections.Generic;

public static partial class LocationLoader
{
	public static Dictionary<string, GameLocation> Load() 
	{
		var locations = new Dictionary<string, GameLocation>();
					locations.Add(@"<h1></h1>
", new GameLocation("", null));
		
		return locations;
	}
}

