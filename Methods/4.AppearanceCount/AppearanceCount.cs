using System;
using System.Linq;

namespace _4.AppearanceCount
{
    class AppearanceCount
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            int appearanceCount = FindNumberAppearanceCount(arr, number);
            Console.WriteLine(appearanceCount);
        }

        private static int FindNumberAppearanceCount(int[] arr, int number)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
