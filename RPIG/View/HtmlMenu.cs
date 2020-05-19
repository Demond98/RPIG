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

			var buttonBackstape = new HTMLButtonElement()
			{
				Style =
				{
					BackgroundColor = "#111",
					BorderColor = "#444",
					BorderWidth = "1px",
					Color = "#aaa",

					Position = "absolute",
					Padding = "14px 0px",
					Height = "30px",
					Width = "75px",
					Left = "65px",
					Top = "0",

					FontSize = "30px",
					LineHeight = "0",
					FontFamily = "Bradley Hand, cursive",
					Cursor = "pointer"
				},
				InnerHTML = "<-"
			};

			var buttonForward = new HTMLButtonElement()
			{
				Style =
				{
					BackgroundColor = "#111",
					BorderColor = "#444",
					BorderWidth = "1px",
					Color = "#aaa",

					Position = "absolute",
					Padding = "14px 0px",
					Height = "30px",
					Width = "75px",
					Left = "150px",
					Top = "0",

					FontSize = "30px",
					LineHeight = "0",
					FontFamily = "Bradley Hand, cursive",
					Cursor = "pointer"
				},
				InnerHTML = "->"
			};

			Element.AppendChild(buttonBackstape);
			Element.AppendChild(buttonForward);
			Element.AppendChild(textElement);
			Document.Body.AppendChild(Element);
		}
	}
}