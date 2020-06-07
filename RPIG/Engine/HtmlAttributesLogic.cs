using Bridge;
using Bridge.Html5;
using System;

namespace RPIG.Engine
{
	public static class HtmlAttributesLogic
	{
		public static TOut CallAttributeFunc<TOut>(this HTMLElement element, string attribute)
		{
			var functionName = element.GetElementAttributeValue(attribute);

			return CallFunction<TOut>(functionName);
		}

		public static string GetElementAttributeValue(this HTMLElement element, string attributeName)
		{
			var value = element.GetAttribute(attributeName);

			if (string.IsNullOrEmpty(value))
				throw new Exception($"attribute '{attributeName}' not found");

			return value;
		}

		public static T CallFunction<T>(string functionName)
			=> Script.Eval<T>($"{functionName}({App.GAME_STATE_PATH})");
	}
}