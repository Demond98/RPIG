using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;

namespace RPIG.View
{
	public class HtmlMenu
	{
		public readonly HTMLDivElement Element;

		public HtmlMenu()
		{
			Element = new HTMLDivElement
			{
				Id = "main-element",
				Style =
				{
					Position = "fixed",
					ZIndex = "50",
					Top = "0",
					Left = "0",
					Width = "19.5em",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					Transition = "left .2s ease-in",
					BackgroundColor = "#111",
					BorderRight = "1px solid #444",
					TextAlign = "center"
				}
			};

			Document.Body.AppendChild(Element);
		}
	}
}
