using System;
using System.Linq;

namespace _5.LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsLargerThenNeighbour(arr, i))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static bool IsLargerThenNeighbour(int[] arr, int index)
        {
            int length = arr.Length;
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0 || index == length - 1)
            {
                return false;
            }
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
            {
                return true;
            }

            return false;
        }
    }
}