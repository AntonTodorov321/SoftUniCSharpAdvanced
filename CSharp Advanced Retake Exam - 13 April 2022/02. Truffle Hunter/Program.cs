using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			char[,] forest = new char[size, size];
			int blackTruffelCounter = 0;
			int summerTruffleCounter = 0;
			int whiteTruffelCounter = 0;
			int wildBoardCounter = 0;


			for (int row = 0; row < size; row++)
			{
				char[] forestInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
				for (int col = 0; col < size; col++)
				{
					forest[row, col] = forestInfo[col];
				}

			}

			while (true)

			{
				string command = Console.ReadLine();

				if (command == "Stop the hunt")
				{
					break;
				}
				string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				if (tokens[0] == "Collect")
				{
					int row = int.Parse(tokens[1]);
					int col = int.Parse(tokens[2]);
					if (isSellValid(row, col, forest))
					{
						if (forest[row, col] == 'B')
						{
							blackTruffelCounter++;
							forest[row, col] = '-';
						}
						else if (forest[row, col] == 'S')
						{
							summerTruffleCounter++;
							forest[row, col] = '-';
						}
						else if (forest[row, col] == 'W')
						{
							whiteTruffelCounter++;
							forest[row, col] = '-';
						}
					}
				}
				else
				{
					int row = int.Parse(tokens[1]);
					int col = int.Parse(tokens[2]);
					string diraction = tokens[3];
					if (isSellValid(row, col, forest))
					{

						if (forest[row, col] != '-')
						{
							wildBoardCounter++;
							forest[row, col] = '-';
						}

						switch (diraction)
						{
							case "up":
								while (isSellValid((row - 2), col, forest))
								{
									if (forest[row, col] != '-')
									{
										wildBoardCounter++;
										forest[row, col] = '-';
									}
									row -= 2;
								}
								break;
							case "down":
								while (isSellValid((row + 2), col, forest))
								{
									if (forest[row, col] != '-')
									{
										wildBoardCounter++;
										forest[row, col] = '-';
									}
									col += 2;
								}
								break;
							case "left":
								while (isSellValid(row, (col - 2), forest))
								{
									if (forest[row, col] != '-')
									{
										wildBoardCounter++;
										forest[row, col] = '-';
									}
									col -= 2;
								}
								break;
							case "right":
								while (isSellValid(row, (col + 2), forest))
								{
									if (forest[row, col] != '-')
									{
										wildBoardCounter++;
										forest[row, col] = '-';
									}
									col += 2;
								}
								break;
						}
					}
				}
			}

			Console.WriteLine($"Peter manages to harvest {blackTruffelCounter} black, {summerTruffleCounter} summer, and {whiteTruffelCounter} white truffles.");
			Console.WriteLine($"The wild boar has eaten {wildBoardCounter} truffles.");

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					Console.Write(forest[row,col] + " ");
				}
				Console.WriteLine();
			}
		}

		private static bool isSellValid(int row, int col, char[,] forest) => row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
	}
}
