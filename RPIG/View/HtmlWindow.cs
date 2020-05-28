using Bridge.Html5;
using RPIG.Engine;
using RPIG.States;
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

		public HtmlWindow()
		{
			Menu = new HtmlMenu();
			Field = new HtmlField();
		}

		public void DrawLocation(State state)
			=> Field.DrawLocation(state);
	}
}