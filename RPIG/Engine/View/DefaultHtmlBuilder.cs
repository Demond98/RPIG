using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine.View
{
	public static class DefaultHtmlBuilder
	{
		public static HTMLDivElement BuildElement()
			=> new HTMLDivElement
			{
				Style =
				{
					Position = "fixed",
					Top = "0",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					TextAlign = "center",
				}
			};
	}
}
