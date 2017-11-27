using System;
using System.Text.RegularExpressions;

namespace _9.ParseURL
{
    class ParseURL
    {
        static void Main()
        {
            string url = Console.ReadLine();

            string pattern = "(\\w*)://([^/]*)(/.*)";

            MatchCollection matches = Regex.Matches(url, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine("[protocol] = {0}", match.Groups[1].Value);
                Console.WriteLine("[server] = {0}", match.Groups[2].Value);
                Console.WriteLine("[resource] = {0}", match.Groups[3].Value);
            }
        }
    }
}