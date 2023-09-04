using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Blacksmith
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] steelInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int[] carbonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			Queue<int> steel = new Queue<int>(steelInfo);
			Stack<int> carbon = new Stack<int>(carbonInfo);
			Dictionary<string, int> possibleSword = new Dictionary<string, int>()
			{
				{"Gladius",70},
				{"Shamshir",80},
				{"Katana",90},
				{"Sabre",110},
				{"Broadsword",150}
			}; 
			Dictionary<string, int> swords = new Dictionary<string, int>()
			{
				{"Gladius",0},
				{"Shamshir",0},
				{"Katana",0},
				{"Sabre",0},
				{"Broadsword",0}
			};

			while (steel.Count>0 && carbon.Count>0)
			{
				int currSteel = steel.Dequeue();
				int currCarbon = carbon.Pop();
				int swordSum = currCarbon + currSteel;

				var sword = possibleSword.FirstOrDefault(x => x.Value == swordSum);

				if (sword.Key==null)
				{
					currCarbon += 5;
					carbon.Push(currCarbon);	
				}
				else
				{
					swords[sword.Key]++;
				}
			}

			Dictionary<string, int> swordLeft = swords.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
			int swordCount = 0;
			foreach (var sword in swordLeft)
			{
				swordCount += sword.Value;
			}

			if (swordLeft.Count>0)
			{
				Console.WriteLine($"You have forged {swordCount} swords.");
			}
			else
			{
				Console.WriteLine($"You did not have enough resources to forge a sword.");
			}

			if (steel.Count==0)
			{
				Console.WriteLine("Steel left: none");
			}
			else
			{
				Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
			}

			if (carbon.Count == 0)
			{
				Console.WriteLine("Carbon left: none");
			}
			else
			{
				Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
			}

			foreach (var sword in swordLeft.OrderBy(x=>x.Key))
			{
				Console.WriteLine($"{sword.Key}: {sword.Value}");
			}
		}
	}
}
