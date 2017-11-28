using System;
using System.Linq;

namespace _2.GetLargestNumber
{
    class GetLargestNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray(); // we will receive 3 numbers maybe

            int currentMax = GetMax(numbers[0], numbers[1]);
            int max = GetMax(currentMax, numbers[2]);

            Console.WriteLine(max);
        }

        private static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}