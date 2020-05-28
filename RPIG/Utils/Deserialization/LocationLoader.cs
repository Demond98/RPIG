using RPIG.Engine;
using RPIG.States;
using System.Collections.Generic;

public static partial class LocationLoader
{
	public static Dictionary<string, GameLocation> Load() 
	{
		var locations = new Dictionary<string, GameLocation>();

		locations.Add(
			"Center",
			new GameLocation (
				@"Several men and women in suits gather around a large conference table in the executive meeting room. The office sits in one of the highest floors of one of the tallest buildings in the city.
<br>
The curtains are drawn closed, and the lights dimmed.
<br>
Older ManI think we have everyone we need here. Let's lock the door and begin our review.
<br>
The man speaking is an older gentleman. His face is aged, but hard and stern. His presence is demanding, and everyone in the room hangs on his words. He motions for another, younger man to proceed.
<br>
Younger ManThank you, sir. We're meeting today, this November 1st, to discuss the incident surrounding the northern branch of our company. Our records will indicate that nearly a year ago, we authorized funding towards an initiative requested by...
<br>
<div class='variable' property='RPIG.App.Game.CurrentState.Player.Money'></div>
The younger man drones on before he is interrupted by a woman sitting near him.
<br>
WomanExcuse me, sir, but I think we're all familiar with the incident itself. I think it would be more beneficial for us now, to know a little bit more about the individual found to be at the center of it all.
<br>
The younger man is clearly irritated by the interruption.
<br>
Younger Man...Yes, of course... Here, the document I'm handing out to you all contains all the pertinent details regarding the individual in question...
<br>
The old man from earlier is fumbling through the stack of files that we given to him.
<br>
Older ManAh, hm... It looks like you've given me too many documents? I'm seeing at least three employee records here, which is the one we're discussing today?

<button class='change-location' 
		is-active='RPIG.GameLogic.GameLogic.FOO'
		is-hide='RPIG.GameLogic.GameLogic.FOO'
		transit='RPIG.GameLogic.GameLogic.ChangeStateFirst'
		next-location='Left'>
	Kek
</button>",
				@"h1 {
}")
			);
		locations.Add(
			"Left",
			new GameLocation (
				@"<h1>Left</h1>",
				@"h1 {
}")
			);
		locations.Add(
			"Right",
			new GameLocation (
				@"<h1>Right</h1>",
				@"h1 {
}")
			);
		
		return locations;
	}
}

