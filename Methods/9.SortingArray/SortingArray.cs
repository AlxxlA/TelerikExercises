using System;
using System.Linq;

namespace _9.SortingArray
{
    class SortingArray
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SortIntArray(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SortIntArray(int[] arr, string sortOrder = "ascending")
        {
            int length = arr.Length;

            // sort descending
            for (int i = 0; i < length; i++)
            {
                int maxElementIndex = MaxElementAfterIndex(arr, i);
                // swap
                int temp = arr[i];
                arr[i] = arr[maxElementIndex];
                arr[maxElementIndex] = temp;
            }

            if (sortOrder == "ascending")
            {
                Array.Reverse(arr);
            }
            else if (sortOrder == "descending")
            {
                // already sorted descending
            }
            else
            {
                throw new ArgumentException("Sorting order should be ascending or descending.By default is ascending.");
            }
        }

        static int MaxElementAfterIndex(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new IndexOutOfRangeException();
            }

            int max = arr[index];
            int maxElementIndex = index;

            for (int i = index; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    maxElementIndex = i;
                    max = arr[i];
                }
            }

            return maxElementIndex;
        }
    }
}