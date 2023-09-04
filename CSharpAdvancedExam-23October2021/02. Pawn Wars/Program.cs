using System;

namespace _02._Pawn_Wars
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = 8;
			char[,] chessBoard = new char[size, size];
			int whiteRow = 0;
			int whiteCol = 0;
			int blackCol = 0;
			int blackRow = 0;

			for (int row = 0; row < size; row++)
			{
				string chessInfo = Console.ReadLine();
				for (int col = 0; col < size; col++)
				{
					chessBoard[row, col] = chessInfo[col];
					if (chessBoard[row, col] == 'w')
					{
						whiteRow = row;
						whiteCol = col;
					}
					if (chessBoard[row, col] == 'b')
					{
						blackCol = col;
						blackRow = row;
					}
				}
			}

			bool isWhiteTurn = true;
			while (true)
			{
				if (isWhiteTurn)
				{
					if (whiteRow==0)
					{
						Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteCol+97)}8.");
						return;
					}
					if (isCellValid(whiteCol-1,whiteRow-1,chessBoard) && chessBoard[whiteRow - 1, whiteCol - 1] == 'b')
					{	
							whiteRow--;
							whiteCol--;
							Console.WriteLine($"Game over! White capture on {(char)(whiteCol+97)}{8-whiteRow}.");
							return;
						
					}
					if (isCellValid(whiteCol+1,whiteRow-1, chessBoard) && chessBoard[whiteRow - 1, whiteCol + 1] == 'b')
					{
							whiteRow--;
							whiteCol++;
							Console.WriteLine($"Game over! White capture on {(char)(whiteCol + 97)}{8 - whiteRow}.");
							return;
						
					}
					whiteRow--;
				}
				else
				{
					if (blackRow == 7)
					{
						Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(whiteCol + 97)}1.");
						return;
					}
					if (isCellValid(blackCol - 1, blackRow + 1, chessBoard) && chessBoard[blackRow + 1, blackCol - 1] == 'b')
					{			
							blackRow++;
							blackCol--;
							Console.WriteLine($"Game over! Black capture on {(char)(blackCol + 97)}{8-blackRow}.");
							return;						
					}
					if (isCellValid(blackCol+1,blackRow+1 ,chessBoard) && chessBoard[blackRow + 1, blackCol + 1] == 'b')
						{
						blackRow++;
						blackRow++;
							Console.WriteLine($"Game over! Black capture on {(char)(blackCol + 97)}{8-blackRow}.");
							return;
					}
					blackRow++;
				}
				isWhiteTurn = !isWhiteTurn;
			}
		}

		static bool isCellValid(int col, int row,char[,] chessBoard) => col >= 0 && col<chessBoard.GetLength(1) && row>=0 && row<8;
	}
}
