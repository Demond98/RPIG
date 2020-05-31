using RPIG.Model;

namespace RPIG.View
{
	public class HtmlWindow
	{
		public readonly HtmlMenu Menu;
		public readonly HtmlField Field;

		public HtmlWindow()
		{
			Menu = new HtmlMenu();
			Field = new HtmlField();
		}

		public void DrawLocation(State state)
			=> Field.DrawLocation(state);
	}
}