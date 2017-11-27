using System;

namespace _4.SubstringInText
{
    class SubstringInText
    {
        static void Main()
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            int patternLength = pattern.Length;
            int count = 0;

            for (int i = 0; i <= text.Length - patternLength; i++)
            {
                string substring = text.Substring(i, patternLength);
                if (pattern == substring)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}