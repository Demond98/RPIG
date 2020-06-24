using Bridge.Html5;
using RPIG.Engine.View.HtmlField;
using RPIG.Model;
using System;

namespace RPIG.View
{
	public class HtmlField
	{
		public readonly HTMLDivElement Element;
		private readonly (string className, Action<HTMLElement> func)[] _setAttributeFuncs;

		public HtmlField()
		{
			Element = HtmlFieldBuilder.BuildElement();
			_setAttributeFuncs = HtmlFieldBuilder.BuildSetAttributesFunctions();

			Document.Body.AppendChild(Element);
		}

		public void DrawLocation(State state)
		{
			Element.InnerHTML = state.Location.HtmlElement.OuterHTML;

			foreach (var (className, func) in _setAttributeFuncs)
				foreach (var element in Element.GetElementsByClassName(className))
					func(element);
		}
	}
}