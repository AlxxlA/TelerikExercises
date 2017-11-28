using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            string sizes = Console.ReadLine();
            int[] firstArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] result = AddArraysDigits(firstArr, secondArr);

            Console.WriteLine(string.Join(" ", result));

        }

        private static int[] AddArraysDigits(int[] firstArr, int[] secondArr)
        {
            List<int> result = new List<int>();

            int largestArrLength = Math.Max(firstArr.Length, secondArr.Length);

            List<int> firstDigits = new List<int>(largestArrLength);
            List<int> secondDigits = new List<int>(largestArrLength);

            for (int i = 0; i < largestArrLength; i++)
            {
                if (i >= firstArr.Length)
                {
                    firstDigits.Add(0);
                }
                else
                {
                    firstDigits.Add(firstArr[i]);
                }
                if (i >= secondArr.Length)
                {
                    secondDigits.Add(0);
                }
                else
                {
                    secondDigits.Add(secondArr[i]);
                }
            }


            int reminder = 0;

            for (int i = 0; i < largestArrLength; i++)
            {
                int sum = firstDigits[i] + secondDigits[i] + reminder;
                reminder = sum / 10;
                int digit = sum % 10;
                result.Add(digit);
            }

            if (reminder != 0)
            {
                result.Add(reminder);
            }

            return result.ToArray();
        }
    }
}