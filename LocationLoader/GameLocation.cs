using System;
using System.Collections.Generic;
using System.Text;

namespace LocationLoader
{
	public class GameLocation
	{
		public string HtmlText { get; set; }
		public string CssText { get; set; }
		public List<string> TransitionFunctions { get; private set; }

		public GameLocation(string htmlText, string cssText, List<string> transitionFunctions)
		{
			HtmlText = htmlText;
			CssText = cssText;
			TransitionFunctions = transitionFunctions;
		}
	}
}
