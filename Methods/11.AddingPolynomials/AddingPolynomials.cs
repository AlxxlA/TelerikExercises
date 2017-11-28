using System;
using System.Linq;

namespace _11.AddingPolynomials
{
    class AddingPolynomials
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal[] firstPolinom = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            decimal[] secondPolinom = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            decimal[] addedPolinoms = AddPolinoms(firstPolinom, secondPolinom);

            Console.WriteLine(string.Join(" ",addedPolinoms));
        }

        private static decimal[] AddPolinoms(decimal[] firstPolinom, decimal[] secondPolinom)
        {
            int length = firstPolinom.Length;
            decimal[] newPolinom = new decimal[length];
            for (int i = 0; i < length; i++)
            {
                newPolinom[i] = firstPolinom[i] + secondPolinom[i];
            }

            return newPolinom;
        }
    }
}