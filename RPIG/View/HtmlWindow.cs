using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}

	public class HtmlWindow
	{
		public readonly HtmlMenu menu;
		public readonly HtmlField field;

		public HtmlWindow()
		{
			menu = new HtmlMenu();
			field = new HtmlField();
		}
	}
}