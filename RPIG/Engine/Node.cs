using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine
{
	public class Node
	{
		public readonly string HtmlText;
		public readonly List<TransitionFunc> TransitionFuncs;

		public Node(string htmlText, params TransitionFunc[] transitionFunc)
		{
			HtmlText = htmlText;
			TransitionFuncs = transitionFunc.ToList();
		}
	}
}