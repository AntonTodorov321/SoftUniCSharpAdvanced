using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondTask
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] miligramsCoffeeInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int[] energyDrinkInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			Stack<int> miligramsCoffee = new Stack<int>(miligramsCoffeeInfo);
			Queue<int> energyDrink = new Queue<int>(energyDrinkInfo);
			int totalMiligramsCofee = 0;

			while (miligramsCoffee.Count > 0 && energyDrink.Count > 0)
			{
				int currMiligramsCoffee = miligramsCoffee.Pop();
				int currEnergyDrink = energyDrink.Dequeue();
				int sumOfCoffee = currMiligramsCoffee * currEnergyDrink;
				if (totalMiligramsCofee + sumOfCoffee >= 300)
				{
					energyDrink.Enqueue(currEnergyDrink);
					if (totalMiligramsCofee - 30 >= 0)
					{
						totalMiligramsCofee -= 30;
					}
				}
				else
				{
					totalMiligramsCofee += sumOfCoffee;
				}
			}

			if (energyDrink.Count == 0)
			{
				Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
			}
			else
			{
				Console.WriteLine($"Drinks left: {string.Join(", ", energyDrink)}");
			}

			Console.WriteLine($"Stamat is going to sleep with {totalMiligramsCofee} mg caffeine.");
		}
	}
}
