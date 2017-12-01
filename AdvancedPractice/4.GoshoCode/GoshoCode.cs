using System;
using System.Text;

namespace _4.GoshoCode
{
    class GoshoCode
    {
        static void Main()
        {
            string keyWord = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                text.Append(line);
            }

            string[] sentences = text.ToString().Split(new char[] { '.', '!' }, StringSplitOptions.RemoveEmptyEntries);
            char[] stopSigns = new char[sentences.Length];

            int index = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.' || text[i] == '!')
                {
                    stopSigns[index] = text[i];
                    index++;
                }
            }


            ulong sum = 0;
            int keyWordLength = keyWord.Length;

            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i];
                int wordStart = sentence.IndexOf(keyWord);

                if (wordStart >= 0)
                {
                    if (stopSigns[i] == '.')
                    {
                        for (int j = wordStart + keyWordLength; j < sentence.Length; j++)
                        {
                            if (sentence[j] != ' ')
                            {
                                sum += (ulong)(sentence[j] * keyWordLength);
                            }
                        }
                    }
                    else if (stopSigns[i] == '!')
                    {
                        for (int j = 0; j < wordStart; j++)
                        {
                            if (sentence[j] != ' ')
                            {
                                sum += (ulong)(sentence[j] * keyWordLength);
                            }
                        }
                    }
                }

            }

            Console.WriteLine(sum);
        }
    }
}