using System;

namespace _02._Help_A_Mole
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			char[,] battleFild = new char[size, size];
			int moleRow = 0;
			int moleCol = 0;
			bool isWin = false;
			int points = 0;


			for (int row = 0; row < size; row++)
			{
				string moleInfo = Console.ReadLine();
				for (int col = 0; col < size; col++)
				{
					battleFild[row, col] = moleInfo[col];
					if (battleFild[row, col] == 'M')
					{
						moleRow = row;
						moleCol = col;
					}
				}
			}

			while (true)
			{
				int originalMoleRow = moleRow;
				int originalMoleCol = moleCol;
				string command = Console.ReadLine();
				if (command == "End")
				{
					break;
				}

				switch (command)
				{
					case "right":
						moleCol++;
						break;
					case "up":
						moleRow--;
						break;
					case "down":
						moleRow++;
						break;
					case "left":
						moleCol--;
						break;
				}

				if (isSellValid(moleRow, moleCol, battleFild))
				{
					if (points > 25)
					{
						isWin = true;
						break;
					}
					else if (battleFild[moleRow, moleCol] == 'S')
					{
						int teleportRow = 0;
						int teleportCol = 0;
						battleFild[moleRow, moleCol] = '-';
						for (int row = 0; row < size; row++)
						{
							for (int col = 0; col < size; col++)
							{
								if (battleFild[row, col] == 'S')
								{
									teleportRow = row;
									teleportCol = col;
								}
							}
						}
						battleFild[teleportRow, teleportCol] = 'M';
						moleRow = teleportRow;
						moleCol = teleportCol;
						points -= 3;
					}
					else if (battleFild[moleRow, moleCol] == '-')
					{
						battleFild[moleRow, moleCol] = 'M';
					}
					else
					{
						int currpoint = int.Parse(battleFild[moleRow, moleCol].ToString());
						points += currpoint;
						battleFild[moleRow, moleCol] = 'M';
					}
					battleFild[originalMoleRow, originalMoleCol] = '-';
				}
				else
				{
					Console.WriteLine("Don't try to escape the playing field!");
					moleRow = originalMoleRow;
					moleCol = originalMoleCol;
				}
			}

			
				if (isWin)
				{
					Console.WriteLine("Yay! The Mole survived another game!");
					Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
				}
				else
				{
					Console.WriteLine("Too bad! The Mole lost this battle!");
					Console.WriteLine($"The Mole lost the game with a total of {points} points.");
				}

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					Console.Write(battleFild[row, col]);
				}
				Console.WriteLine();
			}
			

		}

		private static bool isSellValid(int moleRow, int moleCol, char[,] battleFild) => moleRow >= 0 && moleRow < battleFild.GetLength(0)
	   && moleCol >= 0 && moleCol < battleFild.GetLength(1);
	}
}
