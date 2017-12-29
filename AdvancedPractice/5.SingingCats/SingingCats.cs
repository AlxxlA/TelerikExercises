using System;
using System.Collections.Generic;

namespace _5.SingingCats
{
    class SingingCats
    {
        static void Main()
        {
            string c = Console.ReadLine().Split()[0];
            string s = Console.ReadLine().Split()[0];
            int catsCount = int.Parse(c);
            int songsCount = int.Parse(s);

            string command = Console.ReadLine();


            var songsAndCats = new Dictionary<int, HashSet<int>>(); // song -> cats list

            for (int i = 0; i < songsCount; i++)
            {
                songsAndCats.Add(i + 1, new HashSet<int>());
            }

            while (command != "Mew!")
            {
                string[] commandArgs = command.Split();

                byte cat = byte.Parse(commandArgs[1]);
                byte song = byte.Parse(commandArgs[4]);


                songsAndCats[song].Add(cat);


                command = Console.ReadLine();
            }

            for (int i = 1; i <= songsCount; i++)
            {
                foreach (var combination in Combinations(i, songsCount))
                {
                    var result = new HashSet<int>();
                    foreach (var song in combination)
                    {
                        result.UnionWith(songsAndCats[song]);
                    }
                    if (result.Count == catsCount)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
            }

            Console.WriteLine("No concert!");
        }

        public static IEnumerable<int[]> Combinations(int k, int n)
        {
            int[] result = new int[k];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}