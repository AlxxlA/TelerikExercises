using System;
using System.Linq;

namespace _12.IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main()
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine("{0:f2}", numbers.Average());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(Product(numbers));
        }

        static long Product(long[] numbers)
        {
            long product = 1;

            for (long i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }
            return product;
        }
    }
}