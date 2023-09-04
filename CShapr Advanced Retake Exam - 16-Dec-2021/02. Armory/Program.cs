using System;

namespace _02._Armory
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			char[,] armory = new char[size, size];
			int ofiicerRow = 0;
			int ofiicerCol = 0;
			bool isEnought = false;
			int totalCoins = 0;
			int oficerOriginalRow = 0;
			int oficerOriginalCol = 0;

			for (int row = 0; row < size; row++)
			{
				string armoryInfo = Console.ReadLine();
				for (int col = 0; col < size; col++)
				{
					armory[row, col] = armoryInfo[col];
					if (armory[row, col] == 'A')
					{
						ofiicerRow = row;
						ofiicerCol = col;
					}
				}
			}

			while (true)
			{
				oficerOriginalRow = ofiicerRow;
				oficerOriginalCol = ofiicerCol;

				string command = Console.ReadLine();
				switch (command)
				{
					case "up":
						ofiicerRow--;
						break;
					case "down":
						ofiicerRow++;
						break;
					case "left":
						ofiicerCol--;
						break;
					case "right":
						ofiicerCol++;
						break;
				}

				if (IsSellValid(ofiicerRow, ofiicerCol, armory))
				{
					if (armory[ofiicerRow, ofiicerCol] == 'M')
					{
						armory[oficerOriginalRow, oficerOriginalCol] = '-';
						armory[ofiicerRow, ofiicerCol] = '-';
						int mirorRow = 0;
						int mirorCol = 0;

						for (int row = 0; row < size; row++)
						{
							for (int col = 0; col < size; col++)
							{
								if (armory[row, col] == 'M')
								{
									mirorRow = row;
									mirorCol = col;
								}
							}
						}

						armory[mirorRow, mirorCol] = 'A';
						ofiicerRow = mirorRow;
						ofiicerCol = mirorCol;
					}
					else if (armory[ofiicerRow, ofiicerCol] == '-')
					{
						armory[oficerOriginalRow, oficerOriginalCol] = '-';
						armory[ofiicerRow, ofiicerCol] = 'A';
					}
					else
					{
						totalCoins += int.Parse(armory[ofiicerRow, ofiicerCol].ToString());
						armory[oficerOriginalRow, oficerOriginalCol] = '-';
						armory[ofiicerRow, ofiicerCol] = 'A';
						if (totalCoins >= 65)
						{
							Console.WriteLine("Very nice swords, I will come back for more!");
							break;
						}

					}
				}
				else
				{
					Console.WriteLine("I do not need more swords!");
					isEnought = true;
					armory[oficerOriginalRow, oficerOriginalCol] = '-';
					break;
				}
			}

			Console.WriteLine($"The king paid {totalCoins} gold coins.");
			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					Console.Write(armory[row, col]);
				}
				Console.WriteLine();
			}



			static bool IsSellValid(int row, int col, char[,] armory) => row >= 0 && row < armory.GetLength(0) && col >= 0 && col < armory.GetLength(1);
		}

	}
}
