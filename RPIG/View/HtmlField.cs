using Bridge;
using Bridge.Html5;
using RPIG.Engine;
using RPIG.Model;
using System;
using System.Linq;

namespace RPIG.View
{
	public class HtmlField
	{
		public const string VARIABLE = "variable";
		public const string PROPERTY = "property";
		public const string CHANGE_LOCATION = "change-location";
		public const string TRANSIT = "transit";
		public const string IS_ACTIVE = "is-active";
		public const string IS_HIDE = "is-hide";
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

			Document.Body.AppendChild(Element);
		}

		public void DrawLocation(State state)
		{
			Element.InnerHTML = state.Location.HtmlElement.OuterHTML;

			DrawVariables();
			DrawButtons();
		}

		private void DrawVariables()
		{
			foreach (var element in Element.GetElementsByClassName(VARIABLE))
			{
				var property = element.GetElementAttributeValue(PROPERTY);
				element.TextContent = Script.Eval<object>(property).ToString();
			}
		}

		private void DrawButtons()
		{
			var stateButtonElements = Element.GetElementsByClassName(CHANGE_LOCATION).Cast<HTMLButtonElement>();
			foreach (var button in stateButtonElements)
			{
				button.OnClick = _ => App.ChangeState(button);
				button.Disabled = !button.CallAttributeFunc<bool>(IS_ACTIVE);
				button.Style.Display = button.CallAttributeFunc<bool>(IS_HIDE)
					? "none"
					: "inline";
			}
		}
	}
}