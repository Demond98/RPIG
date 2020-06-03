using Bridge.Html5;

namespace RPIG.Engine
{
	public partial class GameLocation
	{
		public readonly HTMLDivElement HtmlElement;

		public GameLocation(HTMLDivElement htmlElement)
		{
			HtmlElement = htmlElement;
		}

		public GameLocation(string htmlText, string cssText)
		{
			HtmlElement = new HTMLDivElement()
			{
				InnerHTML = htmlText
			};

			HtmlElement.AppendChild(new HTMLStyleElement
			{
				InnerHTML = cssText
			});
		}
	}
}