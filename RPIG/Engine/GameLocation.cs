﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPIG.Engine
{
	public class GameLocation
	{
		public readonly string HtmlText;
		public readonly List<ButtonFunc> TransitionFuncs;

		public GameLocation(string htmlText, params ButtonFunc[] transitionFunc)
		{
			HtmlText = htmlText;
			TransitionFuncs = transitionFunc.ToList();
		}
	}
}