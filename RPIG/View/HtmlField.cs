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

		public void DrawLocation(GameLocation location, State state)
		{
			Task.Run(() =>
			{
				Element.InnerHTML = location.HtmlText;

				foreach (var func in location.TransitionFuncs)
				{
					var button = new HTMLButtonElement();
					button.TextContent = func.Text;
					//TODO ой ой, все неправильно. Здесь не должно быть App
					button.OnClick = App.Game.PushButtonHandler;
					button.Disabled = !func.IsActive(state);

					Element.AppendChild(button);
				}
			});
		}
	}
}