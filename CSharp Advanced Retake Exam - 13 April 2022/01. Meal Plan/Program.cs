using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> possibbleMeat = new Dictionary<string, int>()
			{
				{"salad",350 },
				{"soup",490 },
				{"pasta",680 },
				{"steak",790 }
			};
			Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
			Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
			int mealCounter = 0;

			while (meals.Count > 0 && calories.Count > 0)
			{
				int meal = possibbleMeat[meals.Dequeue()];
				int calorie = calories.Pop();
				if (calorie > meal)
				{
					calorie -= meal;
					mealCounter++;
					calories.Push(calorie);
				}
				else
				{
					meal -= calorie;
					while (meal>0)
					{
						if (calories.Count == 0)
						{
							break;
						}
						int calorieForNextDay = calories.Pop();
						if (calorieForNextDay < meal)
						{
							meal-=calorieForNextDay;
						}
						else
						{
							calorieForNextDay -= meal;
							calories.Push(calorieForNextDay);
							mealCounter++;
						}
					}
				}
			}
			if (meals.Count == 0)
			{
				Console.WriteLine($"John had {mealCounter} meals.");
				Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
			}
			else
			{
				Console.WriteLine($"John ate enough, he had {meals.Count} meals.");
				Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
			}
		}
	}
}
