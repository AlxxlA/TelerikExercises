using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace _8.Messages
{
    class Messages
    {
        static void Main()
        {
            string firstNumber = Console.ReadLine();
            string sign = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            BigInteger num1 = DecryptNumber(firstNumber);
            BigInteger num2 = DecryptNumber(secondNumber);

            BigInteger result = 0;
            if (sign == "+")
            {
                result = num1 + num2;
            }
            else if (sign == "-")
            {
                result = num1 - num2;
            }
            else
            {
                // invalid sign
            }

            string output = EncryptNumber(result);

            Console.WriteLine(output);
        }

        private static string EncryptNumber(BigInteger number)
        {
            Dictionary<char, string> codes = new Dictionary<char, string>()
            {
                { '0', "cad"},
                { '1', "xoz"},
                { '2', "nop"},
                { '3', "cyk"},
                { '4', "min"},
                { '5', "mar"},
                { '6', "kon"},
                { '7', "iva"},
                { '8', "ogi"},
                { '9', "yan"}
            };

            string numToString = number.ToString();
            string result = string.Empty;

            for (int i = 0; i < numToString.Length; i++)
            {
                result += codes[numToString[i]];
            }

            return result;
        }

        private static BigInteger DecryptNumber(string number)
        {
            Dictionary<string, int> codes = new Dictionary<string, int>()
            {
                { "cad", 0},
                { "xoz", 1},
                { "nop", 2},
                { "cyk", 3},
                { "min", 4},
                { "mar", 5},
                { "kon", 6},
                { "iva" ,7},
                { "ogi" ,8},
                { "yan" ,9},
            };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < number.Length; i += 3)
            {
                string digit = number.Substring(i, 3);
                result.Append(codes[digit]);
            }

            return BigInteger.Parse(result.ToString());
        }
    }
}