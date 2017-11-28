using System;
using System.Linq;

namespace _6.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstLargerThenNeighbours = FindFirstLargerThenNeighboursIndex(arr);

            Console.WriteLine(firstLargerThenNeighbours);
        }

        private static int FindFirstLargerThenNeighboursIndex(int[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}