using System;

namespace _3.EnglishDigit
{
    class EnglishDigit
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitAsWord(number));
        }

        private static string LastDigitAsWord(int number)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int lastDigit = number % 10;
            return digits[lastDigit];
        }
    }
}