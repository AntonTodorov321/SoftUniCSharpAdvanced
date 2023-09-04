using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] waterInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
			double[] flourInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
			Queue<double> water = new Queue<double>(waterInfo);
			Stack<double> flour = new Stack<double>(flourInfo);

			Dictionary<string, double> products = new Dictionary<string, double>()
			{
				{"Croissant",0},
				{"Muffin",0},
				{"Baguette",0},
				{"Bagel",0}
			};

			while (water.Count > 0 && flour.Count > 0)
			{
				double currWater = water.Dequeue();
				double currFlour = flour.Pop();
				double totalSum = currFlour + currWater;
				double waterPercent = currWater * 100 / totalSum;
				double flourPercent = currFlour * 100 / totalSum;

				if (waterPercent == 50 && flourPercent == 50)
				{
					products["Croissant"]++;
				}
				else if (waterPercent == 40 && flourPercent == 60)
				{
					products["Muffin"]++;
				}
				else if (waterPercent == 30 && flourPercent == 70)
				{
					products["Baguette"]++;
				}
				else if (waterPercent == 20 && flourPercent == 80)
				{
					products["Bagel"]++;
				}
				else
				{
					currFlour -= currWater;
					products["Croissant"]++;
					flour.Push(currFlour);
				}

			}

			foreach (var product in products.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
			{
				Console.WriteLine($"{product.Key}: {product.Value}");
			}

			if (water.Count > 0)
			{
				Console.WriteLine($"Water left: {string.Join(", ", water)}");
			}
			else
			{
				Console.WriteLine("Water left: None");
			}
			if (flour.Count > 0)
			{
				Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
			}
			else
			{
				Console.WriteLine("Flour left: None");
			}
		}
	}
}
