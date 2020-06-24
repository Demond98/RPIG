using Bridge.Html5;

namespace RPIG.Engine.View
{
	public static class DefaultHtmlBuilder
	{
		public static HTMLDivElement BuildElement()
			=> new HTMLDivElement
			{
				Style =
				{
					Position = "fixed",
					Top = "0",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					TextAlign = "center",
				}
			};
	}
}