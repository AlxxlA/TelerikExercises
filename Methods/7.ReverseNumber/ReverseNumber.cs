using System;
using System.Linq;

namespace _7.ReverseNumber
{
    class ReverseNumber
    {
        static void Main()
        {
            decimal number = decimal.Parse(Console.ReadLine());
            decimal reversedNumber = ReverseDecimalNumber(number);
            Console.WriteLine(reversedNumber);
        }

        static decimal ReverseDecimalNumber(decimal number)
        {
            string reversed = new string(number.ToString().Reverse().ToArray());
            decimal reversedNumber = decimal.Parse(reversed);
            return reversedNumber;
        }
    }
}