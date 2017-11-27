using System;
using System.Text.RegularExpressions;

namespace _5.ParseTags
{
    class ParseTags
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = "<upcase>(.*?)</upcase>";
            MatchEvaluator me = new MatchEvaluator(MatchToUpper);

            string result = Regex.Replace(input, pattern, me);

            Console.WriteLine(result);
        }

        private static string MatchToUpper(Match match)
        {
            string pattern = "<upcase>(.*?)</upcase>";
            string replacement = "$1"; // first group
            Regex rgx = new Regex(pattern);

            string toUpper = rgx.Replace(match.ToString(), replacement).ToUpper(); // replace match with match first group and to upper
            return toUpper;
        }
    }
}