using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;
using RPIG.Engine;

namespace RPIG.View
{
	public class HtmlField
	{
		public readonly HTMLDivElement Element;

		public HtmlField()
		{
			Element = new HTMLDivElement
			{
				Style =
				{
					Position = "fixed",
					ZIndex = "0",
					Top = "0",
					Left = "19.5em",
					Width = "100%",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					Transition = "left .2s ease-in",
					BackgroundColor = "#222",
				}
			};

			Document.Body.AppendChild(Element);
		}

		public void DrawLocation(GameLocation location)
		{
			Element.InnerHTML = location.HtmlText;
		}
	}
}
