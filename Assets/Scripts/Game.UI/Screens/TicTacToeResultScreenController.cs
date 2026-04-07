using Game.Main.Modes;
using Game.UI.Implementation;
using R3;

namespace Game.UI.Screens
{
	public class TicTacToeResultScreenController : AbstractScreenController<TicTacToeResultScreen>, IScreenData<TicTacToeResultScreenController.Data>
	{
		public class Data
		{
			public string winPlayerName { get; }

			public Data(string winPlayerName)
			{
				this.winPlayerName = winPlayerName;
			}
		}

		private readonly IGameMode gameMode;
		private string winPlayerName;
		
		public TicTacToeResultScreenController(IGameMode gameMode)
		{
			this.gameMode = gameMode;
		}

		public override void OnCreate()
		{
			Screen.ContinueButtonObservable.Subscribe(_ => ContinueClicked()).AddTo(Screen);
		}

		private void ContinueClicked()
		{
			gameMode.Complete();
		}

		public override void OnShow()
		{
			Screen.SetWinerName(winPlayerName);
		}

		public void SetData(Data data)
		{
			winPlayerName = data.winPlayerName;
		}
	}
}