using Game.Main.Games;
using Game.UI.Implementation;
using R3;
using UnityEngine;

namespace Game.UI.Screens
{
	public class TicTacToeScreenController : AbstractScreenController<TicTacToeScreen>
	{
		private readonly Subject<Vector2Int> cellViewClickedSubject = new ();

		public Observable<Vector2Int> CellViewClickedObservable => cellViewClickedSubject;
		
		public override void OnCreate()
		{
			var cellVies = Screen.CellViews;
			
			for (var i = 0; i < cellVies.Count; i++)
			{
				var flatIndex = i;
				
				cellVies[i].ButtonClickedObservable.Subscribe(_ => CellViewClicked(flatIndex)).AddTo(Screen);
			}
		}

		public override void OnShow()
		{
			var cellVies = Screen.CellViews;
			
			for (var i = 0; i < cellVies.Count; i++)
			{
				Screen.SetCellView(i, TicTacToeGame.CellFill.None);
			}
		}

		public void SetChangeCellView(Vector2Int index, TicTacToeGame.CellFill cellFill)
		{
			Screen.SetCellView(ToFlatIndex(index), cellFill);
		}

		private void CellViewClicked(int flatIndex)
		{
			var properIndex = ToTwoDimensionIndex(flatIndex);
			
			cellViewClickedSubject.OnNext(properIndex);
		}

		private int ToFlatIndex(Vector2Int twoDimensionsIndex)
		{
			return twoDimensionsIndex.x * TicTacToeScreen.BOARD_SIZE + twoDimensionsIndex.y;
		}
		
		private Vector2Int ToTwoDimensionIndex(int flatIndex)
		{
			return new Vector2Int(flatIndex / TicTacToeScreen.BOARD_SIZE, flatIndex % TicTacToeScreen.BOARD_SIZE);
		}
	}
}