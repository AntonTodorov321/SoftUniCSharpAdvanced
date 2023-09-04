using System;

namespace _02._The_Battle_of_The_Five_Armies
{
	class Program
	{
		static void Main(string[] args)
		{
			int armor = int.Parse(Console.ReadLine());
			int size = int.Parse(Console.ReadLine());
			char[,] battleFild = new char[size, size];
			int armyRow = 0;
			int armyCol = 0;
			int originalArmyRow = 0;
			int originalArmyCol = 0;
			bool isDead = false;

			for (int row = 0; row < size; row++)
			{
				string battleFildInfo = Console.ReadLine();
				for (int col = 0; col < size; col++)
				{
					battleFild[row, col] = battleFildInfo[col];
					if (battleFild[row, col] == 'A')
					{
						armyRow = row;
						armyCol = col;
					}
				}
			}

			battleFild[armyRow, armyCol] = '-';

			while (true)
			{
				string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				originalArmyRow = armyRow;
				originalArmyCol = armyCol;

				switch (tokens[0])
				{
					case "up":
						armyRow--;
						break;
					case "down":
						armyRow++;
						break;
					case "left":
						armyCol--;
						break;
					case "right":
						armyCol++;
						break;
				}

				int enemyRow = int.Parse(tokens[1]);
				int enemyCol = int.Parse(tokens[2]);
				battleFild[enemyRow, enemyCol] = 'O';

				if (isIndexValid(armyRow, armyCol, battleFild))
				{
					if (battleFild[armyRow,armyCol]=='O')
					{
						armor -= 2;
						battleFild[armyRow, armyCol] = '-';
					}
					else if (battleFild[armyRow, armyCol] == 'M')
					{
						armor--;
						battleFild[armyRow, armyCol] = '-';
						break;
					}
					else
					{

					}
					armor--;
				}
				else
				{
					armor--;
					armyRow = originalArmyRow;
					armyCol = originalArmyCol;
				}
				if (armor <= 0)
				{
					battleFild[armyRow, armyCol] = 'X';
					isDead = true;
					break;
				}
			}

			if (isDead)
			{
				Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
			}
			else
			{
				Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
			}

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					Console.Write(battleFild[row,col]);
				}
				Console.WriteLine();
			}
		}

		private static bool isIndexValid(int armyRow, int armyCol, char[,] battleFild) => armyRow >= 0
			&& armyRow < battleFild.GetLength(0)
			&& armyCol >= 0
			&& armyCol < battleFild.GetLength(1);
	}
}
