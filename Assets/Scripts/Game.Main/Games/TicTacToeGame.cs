using System;
using UnityEngine;

namespace Game.Main.Games
{
	public class TicTacToeGame
	{
		[Serializable]
		public enum CellFill
		{
			None = 0,
			X = 1,
			O = 2,
		}
		
		private const int GAME_FIELD_SIZE = 3;
		
		private readonly CellFill[,] gameField;

		public TicTacToeGame()
		{
			gameField = new CellFill[GAME_FIELD_SIZE, GAME_FIELD_SIZE];
		}

		public bool CanFillCell(Vector2Int position)
		{
			if (!IsInBounds(position))
			{
				return false;
			}
			
			return gameField[position.x, position.y] == CellFill.None;
		}

		private bool IsInBounds(Vector2Int position)
		{
			return position.x is >= 0 and <= GAME_FIELD_SIZE - 1 && position.y is >= 0 and <= GAME_FIELD_SIZE - 1;
		}

		public void FillCell(Vector2Int position, CellFill fill)
		{
			if (!CanFillCell(position))
			{
				return;
			}
			
			gameField[position.x, position.y] = fill;
		}

		public bool TryGetWinCellFill(out CellFill winFill)
		{
			//check for rows win
			for (int rowIndex = 0; rowIndex < gameField.GetLength(0); rowIndex++)
			{
				var cellFill = gameField[rowIndex, 0];
				var isEqual = true;

				if (cellFill == CellFill.None)
				{
					continue;
				}
				
				for (int columnIndex = 1; columnIndex < gameField.GetLength(1); columnIndex++)
				{
					if (gameField[rowIndex, columnIndex] != cellFill)
					{
						isEqual = false;
						
						break;
					}
				}

				if (isEqual)
				{
					winFill = cellFill;
					return true;
				}
			}
			
			//check for column win
			for (int columnIndex = 0; columnIndex < gameField.GetLength(1); columnIndex++)
			{
				var cellFill = gameField[0, columnIndex];
				var isEqual = true;
				
				if (cellFill == CellFill.None)
				{
					continue;
				}
				
				for (int rowIndex = 1; rowIndex < gameField.GetLength(0); rowIndex++)
				{
					if (gameField[rowIndex, columnIndex] != cellFill)
					{
						isEqual = false;
						
						break;
					}
				}

				if (isEqual)
				{
					winFill = cellFill;
					return true;
				}
			}
			
			//check for zero diagonal win
			{
				var cellFill = gameField[0, 0];
				var isEqual = cellFill != CellFill.None;
				
				for (int size = 0; size < gameField.GetLength(0); size++)
				{
					if (gameField[size, size] != cellFill)
					{
						isEqual = false;
						
						break;
					}
				}
				
				if (isEqual)
				{
					winFill = cellFill;
					return true;
				}
			}
			
			//check for counter diagonal win
			{
				var cellFill = gameField[0, gameField.GetLength(1) - 1];
				var isEqual = cellFill != CellFill.None;
				var columnMaxIndex = gameField.GetLength(1) - 1;
				
				for (int size = 0; size < gameField.GetLength(0); size++)
				{
					if (gameField[size, columnMaxIndex - size] != cellFill)
					{
						isEqual = false;
						
						break;
					}
				}
				
				if (isEqual)
				{
					winFill = cellFill;
					return true;
				}
			}

			winFill = CellFill.None;
			return false;
		}
	}
}