using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine
{
	public class GameLocation
	{
		public readonly HTMLDivElement HtmlElement;

		public GameLocation(HTMLDivElement htmlElement)
		{
			HtmlElement = htmlElement;
		}

		public GameLocation(string htmlText, string cssText)
		{
			HtmlElement = new HTMLDivElement()
			{
				InnerHTML = htmlText
			};

			HtmlElement.SetAttribute("style", cssText);
		}
	}
}