using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Bridge.Html5;
using RPIG.Engine;
using RPIG.States;

namespace RPIG.View
{
	public class HtmlField
	{
		public const string VARIABLE = "variable";
		public const string PROPERTY = "property";
		
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
					BackgroundColor = "#222",
					TextAlign = "center",
					Color = "#eee"
				}
			};

			PushButtonHandler = pushButtonHandler;
			Document.Body.AppendChild(Element);

			var variableStyleElement = new HTMLStyleElement
			{
				TextContent = ".variable { color: blue; }"
			};

			Document.Body.AppendChild(variableStyleElement);
		}

		public void DrawLocation(State state)
		{
			Task.Run(() =>
			{
				Element.InnerHTML = state.Location.HtmlElement.OuterHTML;

				foreach (var element in Element.GetElementsByClassName(VARIABLE))
				{
					var property = element.GetAttribute(PROPERTY);					
					element.TextContent = Script.Eval<object>(property).ToString();
				}

				foreach (var func in state.Location.ButtonFuncs)
				{
					var button = new HTMLButtonElement
					{
						TextContent = func.Text,
						OnClick = PushButtonHandler,
						Disabled = !func.IsActive(state)
					};

					Element.AppendChild(new HTMLBRElement());
					Element.AppendChild(button);
				}
			});
		}
	}
}