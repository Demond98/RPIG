using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Html5;
using RPIG.Engine;
using RPIG.States;

namespace RPIG.View
{
	public class HtmlField
	{
		public readonly HTMLDivElement Element;
		private readonly Action<MouseEvent<HTMLButtonElement>> PushButtonHandler;

		public HtmlField(Action<MouseEvent<HTMLButtonElement>> pushButtonHandler)
		{
			Element = new HTMLDivElement
			{
				Style =
				{
					Position = "fixed",
					ZIndex = "0",
					Top = "0",
					Left = "18em",
					Width = "calc(100% - 18em)",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					Transition = "left .2s ease-in",
					BackgroundColor = "#222",
					TextAlign = "center",
				}
			};

			PushButtonHandler = pushButtonHandler;

			Document.Body.AppendChild(Element);
		}

		public void DrawLocation(GameLocation location, State state)
		{
			Task.Run(() =>
			{
				Element.InnerHTML = location.HtmlText;

				foreach (var func in location.TransitionFuncs)
				{
					var button = new HTMLButtonElement
					{
						TextContent = func.Text,
						OnClick = PushButtonHandler,
						Disabled = !func.IsActive(state)
					};

					Element.AppendChild(button);
				}
			});
		}
	}
}