using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> possibleDrink = new Dictionary<string, int>()
			{
				{"Cortado",50},
				{"Espresso",75},
				{"Capuccino",100},
				{"Americano",150},
				{"Latte",200}
			};

			Dictionary<string, int> drinks = new Dictionary<string, int>()
			{
				{"Cortado",0},
				{"Espresso",0},
				{"Capuccino",0},
				{"Americano",0},
				{"Latte",0}
			};


			Queue<int> coffeeInfo = new Queue<int>(Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
			Stack<int> milkInfo = new Stack<int>(Console.ReadLine()
				.Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

			while (coffeeInfo.Count>0 && milkInfo.Count>0)
			{
				int coffee = coffeeInfo.Dequeue();
				int milk = milkInfo.Pop();
				int sum = coffee + milk;
				var drink = possibleDrink.FirstOrDefault(x => x.Value == sum);
				if (drink.Key!=null)
				{
					drinks[drink.Key]++;
				}
				else
				{
					milkInfo.Push(milk - 5);
				}
			}

			if (coffeeInfo.Count == 0 && milkInfo.Count == 0)
			{
				Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
			}
			else
			{
				Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
			}

			if (coffeeInfo.Count==0)
			{
				Console.WriteLine("Coffee left: none");
			}
			else
			{
				Console.WriteLine($"Coffee left: {string.Join(", ",coffeeInfo)}");
			}

			if (milkInfo.Count == 0)
			{
				Console.WriteLine("Milk left: none");
			}
			else
			{
				Console.WriteLine($"Milk left: {string.Join(", ", milkInfo)}");
			}

			var sortedDrink = drinks.Where(x => x.Value != 0).OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

			foreach (var drink in sortedDrink)
			{
				Console.WriteLine($"{drink.Key}: {drink.Value}");
			}
		}
	}
}
