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
		public const string CHANGE_LOCATION_LINK = "change-location-link";
		public const string CHANGE_LOCATION_BUTTON = "change-location-button";
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
		
		/// <summary>
		/// TO DO: AnchorElements - Disabled
		/// </summary>
		private void DrawButtons()
		{
			var anchorElements = Element.GetElementsByClassName(CHANGE_LOCATION_LINK).Cast<HTMLAnchorElement>();
			var buttonElements = Element.GetElementsByClassName(CHANGE_LOCATION_BUTTON).Cast<HTMLButtonElement>();

			foreach (var element in anchorElements)
				SetAttributes(element);

			foreach (var element in buttonElements)
				SetAttributes(element);

			//foreach (var element in linksElements)
			//	element.Disabled = !HtmlAttributesLogic.CallFunction<bool>($"{GetClassName(element)}.IsActive");

			foreach (var element in buttonElements)
				element.Disabled = !HtmlAttributesLogic.CallFunction<bool>($"{GetClassName(element)}.IsActive");
		}

		private void SetAttributes(HTMLElement element)
		{
			var className = GetClassName(element);

			element.OnClick = _ => App.ExecuteChangeStateLogic(className);
			element.Style.Display = HtmlAttributesLogic.CallFunction<bool>($"{className}.IsHide")
				? "none"
				: "inline";
		}

		private string GetClassName(HTMLElement element)
			=> $"RPIG.{element.GetAttribute(FUNCTION)}";
	}
}