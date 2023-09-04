using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			char[,] pond = new char[size, size];
			int beaverRow = 0;
			int beaverCol = 0;
			List<char> woodBranch = new List<char>();
			int letterCount = 0;

			for (int row = 0; row < size; row++)
			{
				char[] pondInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
				for (int col = 0; col < size; col++)
				{
					pond[row, col] = pondInfo[col];
					if (pond[row, col] == 'B')
					{
						beaverRow = row;
						beaverCol = col;
					}
					if (char.IsLower(pond[row, col]))
					{
						letterCount++;
					}
				}
			}

			while (true)
			{
				int originalBaeverRow = beaverRow;
				int originalBaeverCol = beaverCol;
				if (letterCount==woodBranch.Count)
				{
					break;
				}
				string command = Console.ReadLine();
				if (command == "end")
				{
					break;
				}

				switch (command)
				{
					case "up":
						beaverRow--;
						break;
					case "right":
						beaverCol++;
						break;
					case "left":
						beaverCol--;
						break;
					case "down":
						beaverRow++;
						break;
				}
				if (IsSellValid(beaverRow, beaverCol, pond))
				{
					if (char.IsLower(pond[beaverRow, beaverCol]))
					{
						woodBranch.Add(pond[beaverRow, beaverCol]);
						pond[beaverRow, beaverCol] = 'B';
					}
					else if (pond[beaverRow, beaverCol] == 'F')
					{
						pond[beaverRow, beaverCol] = '-';
						if (beaverRow == 0 && command!="up")
						{
							beaverRow = size-1;
							if (char.IsLower(pond[beaverRow, beaverCol]))
							{
								woodBranch.Add(pond[beaverRow, beaverCol]);
							}
							pond[beaverRow, beaverCol] = 'B';
						}
						else if (beaverRow == size - 1 && command != "down")
						{
							beaverRow = 0;
							if (char.IsLower(pond[beaverRow, beaverCol]))
							{
								woodBranch.Add(pond[beaverRow, beaverCol]);
							}
							pond[beaverRow, beaverCol] = 'B';
						}
						else if (beaverCol == 0 && command != "down")
						{
							beaverCol = size - 1;
							if (char.IsLower(pond[beaverRow, beaverCol]))
							{
								woodBranch.Add(pond[beaverRow, beaverCol]);
							}
							pond[beaverRow, beaverCol] = 'B';
						}
						else if (beaverCol == size - 1 && command != "left")
						{
							beaverRow = 0;
							if (char.IsLower(pond[beaverRow, beaverCol]))
							{
								woodBranch.Add(pond[beaverRow, beaverCol]);
							}
							pond[beaverRow, beaverCol] = 'B';
						}
						else
						{
							switch (command)
							{
								case "up":
									beaverRow = 0;
									if (char.IsLower(pond[beaverRow, beaverCol]))
									{
										woodBranch.Add(pond[beaverRow, beaverCol]);
									}
									pond[beaverRow, beaverCol] = 'B';
									break;
								case "right":
									beaverCol = size-1;
									if (char.IsLower(pond[beaverRow, beaverCol]))
									{
										woodBranch.Add(pond[beaverRow, beaverCol]);
									}
									pond[beaverRow, beaverCol] = 'B';
									break;
								case "left":
									beaverCol = 0;
									if (char.IsLower(pond[beaverRow, beaverCol]))
									{
										woodBranch.Add(pond[beaverRow, beaverCol]);
									}
									pond[beaverRow, beaverCol] = 'B';
									break;
								case "down":
									beaverRow = size-1;
									if (char.IsLower(pond[beaverRow, beaverCol]))
									{
										woodBranch.Add(pond[beaverRow, beaverCol]);
									}
									pond[beaverRow, beaverCol] = 'B';
									break;
							}
						}
					}
					else
					{
						pond[beaverRow, beaverCol] = 'B';
					}
					pond[originalBaeverRow, originalBaeverCol] = '-';
				}
				else
				{
					beaverRow = originalBaeverRow;
					beaverCol = originalBaeverCol;
					if (woodBranch.Count > 0)
					{
						woodBranch.RemoveAt(woodBranch.Count - 1);
						letterCount--;
					}
				}
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(pond[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
			if (woodBranch.Count==letterCount)
			{
				Console.WriteLine($"The Beaver successfully collect {woodBranch.Count} wood branches: {string.Join(", ",woodBranch)}.");
			}
			else
			{
				Console.WriteLine($"The Beaver failed to collect every wood branch. There are {Math.Abs(woodBranch.Count-letterCount)} branches left.");
			}
				for (int row = 0; row < size; row++)
				{
					for (int col = 0; col < size; col++)
					{
						Console.Write(pond[row, col] + " ");
					}
					Console.WriteLine();
				}
		}


		private static bool IsSellValid(int beaverRow, int beaverCol, char[,] pond) => beaverRow >= 0 && beaverRow < pond.GetLength(0) && beaverCol >= 0 && beaverCol < pond.GetLength(1);
	}
}

