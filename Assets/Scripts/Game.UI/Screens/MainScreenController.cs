using Game.Main.Modes;
using Game.UI.Implementation;
using R3;
using UnityEngine;

namespace Game.UI.Screens
{
	public class MainScreenController : AbstractScreenController<MainScreen>
	{
		private readonly IGameMode gameMode;

		public MainScreenController(IGameMode gameMode)
		{
			this.gameMode = gameMode;
		}
		
		public override void OnCreate()
		{
			Screen.StartButtonObservable.Subscribe(_ => StartButtonClicked()).AddTo(Screen);
		}

		private void StartButtonClicked()
		{
			gameMode.Start();
		}
	}
}