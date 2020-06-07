using Bridge;
using Bridge.Html5;
using System;
using System.Linq;

namespace RPIG.Engine.View.HtmlField
{
	/// <summary>
	/// Функции - ответственные за выполнение определенной логики при отрисовке локации
	/// </summary>
	public static class OnDrawLocationFunctions
	{
		public const string PROPERTY = "property";
		public const string FUNCTION = "function";

		public static void DrawVariable(HTMLElement element)
		{
			var property = element.GetElementAttributeValue(PROPERTY);
			element.TextContent = Script.Eval<object>(property).ToString();
		}

		public static void DrawTextContent(HTMLElement element)
		{
			string functionName = $"RPIG.{element.GetElementAttributeValue(FUNCTION)}.GetTextContent";
			element.TextContent = HtmlAttributesLogic.CallFunction<string>(functionName);
		}

		public static void DrawChangeLocationElement(HTMLElement element)
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