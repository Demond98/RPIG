using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Bridge.Html5;
using RPIG.Engine;
using RPIG.States;

namespace RPIG.View
{
	public class HtmlField
	{
		public const string VARIABLE = "variable";
		public const string PROPERTY = "property";
		public const string CHANGE_LOCATION = "change-location";
		public const string TRANSIT = "transit";
		public const string NEXT_LOCATION = "next-location";
		public const string IS_ACTIVE = "is-active";
		public const string IS_HIDE = "is-hide";


		public readonly HTMLDivElement Element;

		public HtmlField()
		{
			Element = new HTMLDivElement
			{
				Style =
				{
					Position = "fixed",
					ZIndex = "0",
					Top = "0",
					Left = "18em",
					Width = "calc(100% - 18em)",
					Height = "100%",
					Margin = "0",
					Padding = "0",
					BackgroundColor = "#222",
					TextAlign = "center",
					Color = "#eee"
				}
			};

			//PushButtonHandler = pushButtonHandler;
			Document.Body.AppendChild(Element);

			var variableStyleElement = new HTMLStyleElement
			{
				TextContent = ".variable { color: blue; }"
			};

			Document.Body.AppendChild(variableStyleElement);
		}

		public void DrawLocation(State state)
		{
			Task.Run(() =>
			{
				Element.InnerHTML = state.Location.HtmlElement.OuterHTML;

				DrawVariables();
				DrawButtons();
			});
		}

		private void DrawVariables()
		{
			foreach (var element in Element.GetElementsByClassName(VARIABLE))
			{
				var property = element.GetAttribute(PROPERTY);
				element.TextContent = Script.Eval<object>(property).ToString();
			}
		}

		private void DrawButtons()
		{
			var stateButtonElements = Element.GetElementsByClassName(CHANGE_LOCATION).Cast<HTMLButtonElement>();
			foreach (var stateButton in stateButtonElements)
			{
				var transitFuncBody = GetStateButtonAttribute(stateButton, TRANSIT);
				var nextStateName = GetStateButtonAttribute(stateButton, NEXT_LOCATION);

				stateButton.OnClick = _ => App.ChangeState(transitFuncBody, nextStateName);
				stateButton.Disabled = ButtonFuncPredicate(stateButton, IS_ACTIVE);
				stateButton.Hidden = ButtonFuncPredicate(stateButton, IS_HIDE);
			}
		}

		private bool ButtonFuncPredicate(HTMLButtonElement stateButton, string attributeName)
			=> Script.Eval<bool>($"{GetStateButtonAttribute(stateButton, attributeName)}({App.GAME_CURRENTSTATE})");

		private string GetStateButtonAttribute(HTMLButtonElement stateButton, string attributeName)
		{
			var value = stateButton.GetAttribute(attributeName);

			return (!string.IsNullOrEmpty(value)) ? value : throw new Exception($"{nameof(value)} is empty");
		}
	}
}