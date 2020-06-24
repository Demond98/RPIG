using Bridge.Html5;
using RPIG.Engine.View.HtmlMenu;

namespace RPIG.View
{
	public class HtmlMenu
	{
		public readonly HTMLDivElement Element;

		public HtmlMenu()
		{
			var documentBody = Document.Body;
			documentBody.AppendChild(HtmlMenuBuilder.BuildMenuStyle());
			Element = HtmlMenuBuilder.BuildElement();
			documentBody.AppendChild(Element);
		}
	}
}