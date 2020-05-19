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
		//public readonly string HtmlText;
		public readonly HTMLDivElement HtmlElement;
		public readonly List<ButtonFunc> ButtonFuncs;

		public GameLocation(HTMLDivElement htmlElement, params ButtonFunc[] buttonFuncs)
		{
			HtmlElement = htmlElement;
			ButtonFuncs = buttonFuncs.ToList();
		}

		public GameLocation(string htmlText, string cssText, params ButtonFunc[] buttonFuncs)
		{
			HtmlElement = new HTMLDivElement()
			{
				InnerHTML = htmlText
			};

			HtmlElement.SetAttribute("style", cssText);

			ButtonFuncs = buttonFuncs.ToList();
		}
	}
}