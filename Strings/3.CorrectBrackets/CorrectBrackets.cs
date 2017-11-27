using System;
using System.Collections;

namespace _3.CorrectBrackets
{
    class CorrectBrackets
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (IsValidBrackets(input))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }

        private static bool IsValidBrackets(string text)
        {
            Stack brackets = new Stack();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (currentChar == '(')
                {
                    brackets.Push(currentChar);
                }
                else if (currentChar == ')')
                {
                    if (brackets.Count == 0)
                    {
                        return false;
                    }
                    brackets.Pop();
                }
            }
            if (brackets.Count != 0)
            {
                return false;
            }
            return true;
        }
    }
}