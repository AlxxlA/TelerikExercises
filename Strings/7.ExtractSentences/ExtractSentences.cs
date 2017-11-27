using System;
using System.Text.RegularExpressions;

namespace _7.ExtractSentences
{
    class Program
    {
        static void Main()
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split('.');

            string wordPattern = string.Format("(^|[^a-zA-Z]){0}([^a-zA-Z]|$)", keyWord);
            Regex regex = new Regex(wordPattern);

            foreach (string sentence in sentences)
            {
                Match match = regex.Match(sentence);

                if (match.Success)
                {
                    Console.Write(sentence + ".");
                }
            }
        }
    }
}