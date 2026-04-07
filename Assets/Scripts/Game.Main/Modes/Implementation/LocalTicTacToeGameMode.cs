using System.Collections.Generic;
using System.Linq;
using Game.Main.Games;
using Game.UI;
using Game.UI.Screens;
using R3;
using UnityEngine;
using CompositeDisposable = R3.CompositeDisposable;

namespace Game.Main.Modes.Implementation
{
	public class LocalTicTacToeGameMode : AbstractGameMode
	{
		private readonly IScreensSystem screensSystem;
		private CompositeDisposable disposables;
		private TicTacToeGame game;
		private IMoveQueue moveQueue;
		private TicTacToeScreenController screenController;
		
		private readonly Dictionary<string, TicTacToeGame.CellFill> playerFills = new ()
		{
			{"player1", TicTacToeGame.CellFill.X},
			{"player2", TicTacToeGame.CellFill.O},
		};

		public LocalTicTacToeGameMode(IScreensSystem screensSystem)
		{
			this.screensSystem = screensSystem;
		}
		
		protected async override void OnStart()
		{
			disposables?.Dispose();
			disposables = new CompositeDisposable();

			moveQueue = new LoopMoveQueue(playerFills.Keys.ToArray());
			game = new TicTacToeGame();
			
			screenController = await screensSystem.PushAsync<TicTacToeScreenController>();

			screenController.CellViewClickedObservable.Subscribe(CellViewClicked);
		}

		private void CellViewClicked(Vector2Int index)
		{
			if (!game.CanFillCell(index))
			{
				return;
			}
			
			game.FillCell(index, playerFills[moveQueue.GetCurrent()]);
			screenController.SetChangeCellView(index, playerFills[moveQueue.GetCurrent()]);
			
			if (game.TryGetWinCellFill(out var winnerCell))
			{
				screensSystem.Push<TicTacToeResultScreenController, TicTacToeResultScreenController.Data>(
					new TicTacToeResultScreenController.Data(moveQueue.GetCurrent()));
				
				return;
			}
			
			moveQueue.Move();
		}

		protected override void OnComplete()
		{
			disposables?.Dispose();
			
			screensSystem.PopAll();
			screensSystem.Push<MainScreenController>();
		}
	}
}