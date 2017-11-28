using System;
using System.Numerics;

namespace _10.Factorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var factorial = NFactorial(n);
            Console.WriteLine(factorial);
            
        }

        private static BigInteger NFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("To calculate Factorial number shoud be natural number.");
            }

            BigInteger result = new BigInteger(1);
                        
            for (int i = 1; i <= n; i++)
            {
                result = BigInteger.Multiply(result, i);
            }

            return result;
        }

        //static int[] MultiplyDigitArrayByInt(int[] digits, int number)
        //{
        //    int length = digits.Length;

        //    int[] result = new int[] { };

        //    for (int i = 0; i < length; i++)
        //    {
        //        string current = (number * digits[i]).ToString() + new string('0', length - i - 1);

        //        int[] currentMultiplication = new int[current.Length];
        //        for (int j = 0; j < current.Length; j++)
        //        {
        //            currentMultiplication[j] = current[j] - 48;
        //        }
        //        result = SumDigitsArray(result.ToArray(), currentMultiplication);
        //    }

        //    return result;
        //}

        //static int[] SumDigitsArray(int[] firstArr, int[] secoundArr)
        //{
        //    Stack<int> result = new Stack<int>();
        //    //  Console.WriteLine(string.Join("", firstArr));
        //    //  Console.WriteLine(string.Join("", secoundArr));

        //    int firstIndex = firstArr.Length - 1;
        //    int secondIndex = secoundArr.Length - 1;

        //    int reminder = 0;

        //    while (firstIndex >= 0 || secondIndex >= 0)
        //    {
        //        int firstDigit = 0;
        //        int secondDigit = 0;
        //        if (firstIndex >= 0)
        //        {
        //            firstDigit = firstArr[firstIndex];
        //        }
        //        if (secondIndex >= 0)
        //        {
        //            secondDigit = secoundArr[secondIndex];
        //        }

        //        int sum = firstDigit + secondDigit + reminder;
        //        reminder = sum / 10;
        //        int digit = sum % 10;
        //        result.Push(digit);

        //        firstIndex--;
        //        secondIndex--;
        //    }


        //    return result.ToArray();
        //}
    }
}