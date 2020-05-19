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
					BackgroundColor = "#111",
					BorderRight = "1px solid #444",
					TextAlign = "center",
					OverflowY = "auto"
				}
			};

			var textElement = new HTMLLabelElement
			{
				TextContent = "AltRight",
				ClassName = "menu-text",
				Style =
				{
					FontSize = "38px",
					Top = "50px",
					Position = "relative"
				}
			};

			var menuStyle = new HTMLStyleElement
			{
				InnerHTML = @"
					.menu-button {
						background-color: #111;
						border-color: #444;
						border-width: 1px;
						line-height: 0;
						font-family: Bradley Hand, cursive;
						cursor: pointer;
					}

					.menu-text {
						color: #aaa;
					}
				",
			};

			var buttonBackstape = new HTMLButtonElement
			{
				InnerHTML = "<-",
				ClassName = "menu-button menu-text",
				Style =
				{
					FontSize = "30px",
					Position = "absolute",
					Padding = "14px 0px",
					Height = "30px",
					Width = "75px",
					Left = "65px",
					Top = "0"
				},
			};

			var buttonForward = new HTMLButtonElement
			{
				InnerHTML = "->",
				ClassName = "menu-button menu-text",
				Style =
				{
					FontSize = "30px",
					Position = "absolute",
					Padding = "14px 0px",
					Height = "30px",
					Width = "75px",
					Left = "150px",
					Top = "0",
				},
			};

			Document.Body.AppendChild(menuStyle);
			Element.AppendChild(buttonBackstape);
			Element.AppendChild(buttonForward);
			Element.AppendChild(textElement);
			Document.Body.AppendChild(Element);
		}
	}
}