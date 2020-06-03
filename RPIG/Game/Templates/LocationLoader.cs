using RPIG.Engine;
using System.Collections.Generic;

namespace RPIG
{
	public static partial class LocationLoader
	{
		public static Dictionary<App.LocationName, GameLocation> Load() 
		{
			return new Dictionary<App.LocationName, GameLocation>()
			{
			[App.LocationName.Main] = new GameLocation (
				@"<h1>Добро пожаловать на ферму</h1>

На данной ферме, вы можете купить коров

<br>
Ваши деньги: <div class='variable' property='RPIG.App.Game.CurrentState.Player.Money'></div> руб.
<br>
Количество коров: <div class='variable' property='RPIG.App.Game.CurrentState.Player.Cows.Count'></div>

<a id='go-to-shop'
		href='#'
		class='change-location'
        function='GoToShop'>
	В магазин
</a>

<br>

<button 
		id='work-at-factory'
		class='change-location'
        function='WorkAtFactory'>
    Поработать на заводе
</button>",
				@".variable {
    color: #106363;
    display: compact;
}
"),
			[App.LocationName.Shop] = new GameLocation (
				@"<h1>Магазин</h1>

Вы можете купить корову
<br>
Стоимость:
<div class='variable' property='RPIG.Model.Characters.Cow.Price'></div> руб.


<button 
		id='buy-cow'
		class='change-location'
        function='BuyCow'>
    Купить корову
</button>

<br>

<button 
		id='go=to-farm'
		class='change-location'
        function='GoToFarm'>
    Вернуться на ферму
</button>",
				@".variable {
    color: #106363;
    display: compact;
}"),
			};
		}
	}
}