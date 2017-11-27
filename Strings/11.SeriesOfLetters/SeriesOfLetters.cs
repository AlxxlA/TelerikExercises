using System;
using System.Collections.Generic;
using System.Text;

namespace _11.SeriesOfLetters
{
    class SeriesOfLetters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            LinkedList<char> list = new LinkedList<char>();
            
            foreach (var ch in input)
            {
                if (list.Count == 0 || !(list.Last.Value == ch))
                {
                    output.Append(ch);
                    list.AddLast(ch);
                }
            }

            Console.WriteLine(output);
        }
    }
}