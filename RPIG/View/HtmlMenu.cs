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
					Width = "18em",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					Transition = "left .2s ease-in",
					BackgroundColor = "#111",
					BorderRight = "1px solid #444",
					TextAlign = "center",
					OverflowY = "auto"
				}
			};

			var textElement = new HTMLLabelElement()
			{
				TextContent = "AltRight",
				Style =
				{
					Color = "#aaa",
					FontSize = "38px",
					Top = "50px",
					Position = "relative"
				}
			};

			var button = new HTMLButtonElement()
			{
				Style =
				{ 
					BackgroundColor = "#111",
					BorderColor = "#444",
					BorderWidth = "1px",

					Position = "absolute",
					Padding = "15px",
					Right = "0",
					Top = "0",

					Cursor = "pointer"
				}
			};

			Element.AppendChild(button);
			Element.AppendChild(textElement);
			Document.Body.AppendChild(Element);
		}
	}
}