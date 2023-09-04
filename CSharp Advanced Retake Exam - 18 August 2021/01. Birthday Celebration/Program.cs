using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] guestCapacityInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int[] platesInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int wastedGrams = 0;

			Queue<int> guestCapacity = new Queue<int>(guestCapacityInfo);
			Stack<int> plates = new Stack<int>(platesInfo);

			while (guestCapacity.Count > 0 && plates.Count > 0)
			{
				int currGuestCapacity = guestCapacity.Peek();
				int currPlate = plates.Peek();

				if (currPlate >= currGuestCapacity)
				{
					wastedGrams += currPlate - currGuestCapacity;
					guestCapacity.Dequeue();
					plates.Pop();
				}
				else
				{
					currGuestCapacity -= currPlate;
					plates.Pop();
					while (true)
					{
						if (plates.Count == 0)
						{
							break;
						}
						currPlate = plates.Pop();

						if (currPlate<currGuestCapacity)
						{
							currGuestCapacity -= currPlate;
						}
						else
						{
							wastedGrams += currPlate - currGuestCapacity;
							guestCapacity.Dequeue();
							break;
						}
					}
				}
			}

			if (guestCapacity.Count==0)
			{
				Console.WriteLine($"Plates: {string.Join(" ",plates)}");
			}
			else
			{
				Console.WriteLine($"Guests: {string.Join(" ", guestCapacity)}");
			}
			Console.WriteLine($"Wasted grams of food: {wastedGrams}");
		}
	}
}
