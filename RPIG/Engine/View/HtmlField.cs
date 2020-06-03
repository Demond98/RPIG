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
		public const string CHANGEABLE_TEXT = "changeable-text";
		public const string FUNCTION = "function";
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
			DrawChangeLocationElements();
			DrawTextContent();
		}

		private void DrawTextContent()
		{
			foreach (var element in Element.GetElementsByClassName(CHANGEABLE_TEXT))
			{
				string functionName = $"RPIG.{element.GetAttribute(FUNCTION)}.GetTextContent";
				element.TextContent = HtmlAttributesLogic.CallFunction<string>(functionName);
			}
		}

		private void DrawVariables()
		{
			foreach (var element in Element.GetElementsByClassName(VARIABLE))
			{
				var property = element.GetElementAttributeValue(PROPERTY);
				element.TextContent = Script.Eval<object>(property).ToString();
			}
		}

		private void DrawChangeLocationElements()
		{
			foreach (var element in Element.GetElementsByClassName(CHANGE_LOCATION))
			{
				var className = $"RPIG.{element.GetAttribute(FUNCTION)}";

				if (!element.TagName.Equals("a", StringComparison.OrdinalIgnoreCase))
					element.Cast<HTMLButtonElement>().Disabled = !HtmlAttributesLogic.CallFunction<bool>($"{className}.IsActive");

				element.OnClick = _ => App.ExecuteChangeStateLogic(className);
				element.Style.Display = HtmlAttributesLogic.CallFunction<bool>($"{className}.IsHide")
					? "none"
					: "inline";
			}
		}
	}
}