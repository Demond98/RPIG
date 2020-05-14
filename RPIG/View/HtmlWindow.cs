using Bridge.Html5;
using RPIG.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.View
{
	public class HtmlWindow
	{
		public readonly HtmlMenu Menu;
		public readonly HtmlField Field;

		public HtmlWindow(Game game)
		{
			Menu = new HtmlMenu();
			Field = new HtmlField();

			Field.DrawLocation(game.CurrentLocation, game.CurrentState);
			game.LocationChanged += Field.DrawLocation;
		}
	}
}