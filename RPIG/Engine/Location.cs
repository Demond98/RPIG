using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine
{
	public class Location
	{
		public readonly string HtmlText;
		public readonly List<TransitionFunc> TransitionFuncs;

		public Location(string htmlText, params TransitionFunc[] transitionFunc)
		{
			HtmlText = htmlText;
			TransitionFuncs = transitionFunc.ToList();
		}
	}
}