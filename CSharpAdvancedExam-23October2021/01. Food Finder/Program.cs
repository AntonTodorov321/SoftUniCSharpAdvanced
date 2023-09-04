using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>()
			{
				{"pear",new HashSet<char>()},
				{"flour",new HashSet<char>()},
				{"pork",new HashSet<char>()},
				{"olive",new HashSet<char>()}
			};
			Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
			Stack<char> consanans = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

			while (consanans.Count>0)
			{
				char vowel = vowels.Dequeue();
				char consanan = consanans.Pop();

				foreach (var word in words.Keys)
				{
					if (word.Contains(vowel))
					{
						words[word].Add(vowel);
					}
					if (word.Contains(consanan))
					{
						words[word].Add(consanan);
					}
				}

				vowels.Enqueue(vowel);
			}

			List<string> filtredWords = words.Where(x => x.Key.Length == x.Value.Count).Select(x => x.Key).ToList();

			Console.WriteLine($"Words found: {filtredWords.Count}");
			foreach (var word in filtredWords)
			{
				Console.WriteLine(word);
			}
		}
	}
}
