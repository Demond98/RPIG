using Bridge.Html5;

namespace RPIG.Engine.View.HtmlMenu
{
	public static class HtmlMenuBuilder
	{
		public static HTMLDivElement BuildElement()
		{
			var htmlElement = DefaultHtmlBuilder.BuildElement();
			var style = htmlElement.Style;
			style.ZIndex = "50";
			style.Left = "0";
			style.Width = "18em";
			style.BackgroundColor = "#111";
			style.BorderRight = "1px solid #444";
			style.OverflowY = "auto";

			htmlElement.AppendChild(BuildButtonBackWard());
			htmlElement.AppendChild(BuildButtonForward());
			htmlElement.AppendChild(BuildLabel());

			return htmlElement;
		}

		public static HTMLStyleElement BuildMenuStyle()
			=> new HTMLStyleElement
			{
				InnerHTML = @"
							.menu-button {
								background-color: #111;
								border-color: #444;
								border-width: 1px;
								line-height: 0;
								font-family: Bradley Hand, cursive;
								cursor: pointer;
							}

							.menu-text {
								color: #aaa;
							}"
			};

		private static HTMLLabelElement BuildLabel()
			 => new HTMLLabelElement
			 {
				 TextContent = "AltRight",
				 ClassName = "menu-text",
				 Style =
				 {
				 	FontSize = "38px",
				 	Top = "50px",
				 	Position = "relative"
				 }
			 };

		private static HTMLButtonElement BuildButtonForward()
		{
			var arrowButton = BuildArrowButton();
			arrowButton.InnerHTML = "->";
			arrowButton.Style.Left = "150px";
			arrowButton.OnClick = App.HistoryForward;

			return arrowButton;
		}

		private static HTMLButtonElement BuildButtonBackWard()
		{
			var arrowButton = BuildArrowButton();
			arrowButton.InnerHTML = "<-";
			arrowButton.Style.Left = "65px";
			arrowButton.OnClick = App.HistoryBackward;

			return arrowButton;
		}

		private static HTMLButtonElement BuildArrowButton()
			=> new HTMLButtonElement
			{
				ClassName = "menu-button menu-text",
				Style =
				{
					FontSize = "30px",
					Position = "absolute",
					Padding = "14px 0px",
					Height = "30px",
					Width = "75px",
					Top = "0"
				}
			};
	}
}