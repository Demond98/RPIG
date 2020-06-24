using Bridge.Html5;
using System;

namespace RPIG.Engine.View.HtmlField
{
	public static class HtmlFieldBuilder
	{
		public const string VARIABLE = "variable";
		public const string CHANGE_LOCATION = "change-location";
		public const string CHANGEABLE_TEXT = "changeable-text";

		public static HTMLDivElement BuildElement()
		{
			var element = DefaultHtmlBuilder.BuildElement();
			var style = element.Style;
			style.ZIndex = "0";
			style.Left = "18em";
			style.Width = "calc(100% - 18em)";
			style.BackgroundColor = "#222";
			style.Color = "#eee";

			return element;
		}

		public static (string className, Action<HTMLElement> func)[] BuildSetAttributesFunctions()
		{
			//Если возвращать через лямбду, то ошибка компиляции - bridge.net
			return new (string className, Action<HTMLElement> func)[]
			{
				(CHANGEABLE_TEXT, OnDrawLocationFunctions.DrawTextContent),
				(VARIABLE, OnDrawLocationFunctions.DrawVariable),
				(CHANGE_LOCATION, OnDrawLocationFunctions.DrawChangeLocationElement)
			};
		}
	}
}