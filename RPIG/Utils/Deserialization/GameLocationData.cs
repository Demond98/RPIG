using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Utils.Deserialization
{
	public class GameLocationData
	{
		public string HtmlText { get; set; }
		public string CssText { get; set; }
		public List<string> TransitionFunctions { get; }
		public GameLocationData(string htmlText, string cssText, List<string> transitionFunctions)
		{
			HtmlText = htmlText;
			CssText = cssText;
			TransitionFunctions = transitionFunctions;
		}
	}
}
