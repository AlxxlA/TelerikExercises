using System;

namespace _2.MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);

            PrintMatrix(matrix);

            int maxSum = FindMaxSum(matrix);
            Console.WriteLine(maxSum);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                string[] nums = Console.ReadLine().Split();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(nums[j]);
                }
            }
        }

        private static int FindMaxSum(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxSum = int.MinValue;

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    int startRow = Math.Max(0, i - 1);
                    int endRow = Math.Min(rows - 1, i + 1);

                    int startCol = Math.Max(0, j - 1);
                    int endCol = Math.Min(cols - 1, j + 1);

                    int currentSum = FindSquareSum(matrix, startRow, endRow, startCol, endCol);

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            return maxSum;
        }

        private static int FindSquareSum(int[,] matrix, int startRow, int endRow, int startCol, int endCol)
        {
            int sum = 0;

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = string.Empty;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row += matrix[i, j] + " ";
                }
                Console.WriteLine(row.Trim());
            }
        }
    }
}
