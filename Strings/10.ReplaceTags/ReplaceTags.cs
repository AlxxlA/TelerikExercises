using System;
using System.Text.RegularExpressions;

namespace _10.ReplaceTags
{
    class ReplaceTags
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string tagPattern = "(<a href=\".*?\">.*?</a>)";

            MatchEvaluator me = new MatchEvaluator(ReplaceTag);

            string result = Regex.Replace(input, tagPattern, me);

            Console.WriteLine(result);
        }

        private static string ReplaceTag(Match match)
        {
            // extract text and url from tag <a href="URL">TEXT</a>
            string tag = match.Value;
            string textAndUrlPattern = "\"(.*?)\">(.*?)<";

            Regex textAndUrlRgx = new Regex(textAndUrlPattern);

            Match tagAndUrl = textAndUrlRgx.Match(tag);
            string url = tagAndUrl.Groups[1].Value;
            string text = tagAndUrl.Groups[2].Value;
            // end of extract

            // replace tag with [text](url)
            string replacement = string.Format("[{0}]({1})", text, url);

            string tagPattern = "(<a href=\".*?\">.*?</a>)";
            Regex rgx = new Regex(tagPattern);

            string replaced = rgx.Replace(tag, replacement); // replace match with match first group and to upper
            return replaced;
        }
    }
}