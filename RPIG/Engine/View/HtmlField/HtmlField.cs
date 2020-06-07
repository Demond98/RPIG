using Bridge.Html5;
using RPIG.Engine.View.HtmlField;
using RPIG.Model;
using System;

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

		private readonly (string className, Action<HTMLElement> func)[] _setAttributeFuncs =
			new (string className, Action<HTMLElement> func)[]
			{
				(CHANGEABLE_TEXT, OnDrawLocationFunctions.DrawTextContent),
				(VARIABLE, OnDrawLocationFunctions.DrawVariable),
				(CHANGE_LOCATION, OnDrawLocationFunctions.DrawChangeLocationElement)
			};

		public void DrawLocation(State state)
		{
			Element.InnerHTML = state.Location.HtmlElement.OuterHTML;

			foreach (var (className, func) in _setAttributeFuncs)
				foreach (var element in Element.GetElementsByClassName(className))
					func(element);
		}
	}
}