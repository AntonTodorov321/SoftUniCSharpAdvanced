using System;
using System.Linq;

namespace FirstTask
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			string carNumber = Console.ReadLine();
			char[,] carRace = new char[size, size];
			int carRow = 0;
			int carCol = 0;
			bool isFinish = false;
			int totoalDistance = 0;
			int tunelRow = 0;
			int tunelCol = 0;

			for (int row = 0; row < size; row++)
			{
				char[] raceInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

				for (int col = 0; col < size; col++)
				{
					carRace[row, col] = raceInfo[col];
				}
			}

			while (true)
			{
				int originalCarRow = carRow;
				int originalCarCol = carCol;
				if (carRace[carRow, carCol] == 'F')
				{
					carRace[originalCarRow, originalCarCol] = '.';
					carRace[carRow, carCol] = 'C';
					isFinish = true;
					break;
				}
				if (carRace[carRow, carCol] == 'T')
				{
					totoalDistance += 30;
					carRace[originalCarRow, originalCarCol] = '.';
					carRace[carRow, carCol] = '.';

					for (int row = 0; row < size; row++)
					{
						for (int col = 0; col < size; col++)
						{
							if (carRace[row, col] == 'T')
							{
								tunelRow = row;
								tunelCol = col;
							}
						}
					}
						carRace[tunelRow, tunelCol] = 'C';
						carRow = tunelRow;
						carCol = tunelCol;
						originalCarRow = carRow;
						originalCarCol = carCol;
				}


				string command = Console.ReadLine();
				if (command == "End")
				{
					break;
				}

				switch (command)
				{
					case "up":
						carRow--;
						break;
					case "down":
						carRow++;
						break;
					case "right":
						carCol++;
						break;
					case "left":
						carCol--;
						break;
				}

				if (carRace[carRow, carCol] == '.')
				{
					totoalDistance += 10;
					carRace[carRow, carCol] = 'C';
					carRace[originalCarRow, originalCarCol] = '.';
				}
				else if (carRace[carRow, carCol] == 'F')
				{
					totoalDistance += 10;
					carRace[originalCarRow, originalCarCol] = '.';
					carRace[carRow, carCol] = 'C';
					isFinish = true;
					break;
				}
				else
				{
					totoalDistance += 30;
					carRace[originalCarRow, originalCarCol] = '.';
					carRace[carRow, carCol] = '.';
					tunelRow = 0;
					tunelCol = 0;

					for (int row = 0; row < size; row++)
					{
						for (int col = 0; col < size; col++)
						{
							if (carRace[row, col] == 'T')
							{
								tunelRow = row;
								tunelCol = col;
							}
						}
					}

					carRace[tunelRow, tunelCol] = 'C';
					carRow = tunelRow;
					carCol = tunelCol;
				}
				Console.WriteLine(totoalDistance);
				for (int row = 0; row < size; row++)
				{
					for (int col = 0; col < size; col++)
					{
						Console.Write(carRace[row, col]);
					}
					Console.WriteLine();
				}
				Console.WriteLine();
				Console.WriteLine();

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(carRace[row, col]);
                    }
                    Console.WriteLine();
                }

            }
			if (isFinish)
			{
				Console.WriteLine($"Racing car {carNumber} finished the stage!");
			}
			else
			{
				Console.WriteLine($"Racing car {carNumber} DNF.");
			}

			Console.WriteLine($"Distance covered {totoalDistance} km.");

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					Console.Write(carRace[row, col]);
				}
				Console.WriteLine();
			}
		}
	}
}
