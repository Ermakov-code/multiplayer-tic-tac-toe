using System;
using System.Collections.Generic;
using System.Linq;
using Game.Main.Games;
using Game.UI.Common;
using Game.UI.Implementation;
using UnityEngine;

namespace Game.UI.Screens
{
	public class TicTacToeScreen : AbstractScreen
	{
		[Serializable]
		public class CellFill
		{
			[field: SerializeField]
			public TicTacToeGame.CellFill Fill { get; private set; }
			
			[field: SerializeField]
			public string Text { get; private set; }
		}
		
		public const int BOARD_SIZE = 3;
		
		//should be in propper order starting from left upper corner
		[SerializeField]
		private TicTacToeCellView[] ticTacToeCellView;

		[SerializeField]
		private CellFill[] cellFills;

		public IReadOnlyList<TicTacToeCellView> CellViews => ticTacToeCellView;

		public void SetCellView(int index, TicTacToeGame.CellFill cellFill)
		{
			var fillLabel = cellFills.FirstOrDefault(cf => cf.Fill == cellFill)?.Text;
			
			CellViews[index].SetLabel(fillLabel);
		}
	}
}