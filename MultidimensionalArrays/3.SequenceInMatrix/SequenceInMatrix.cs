using System;
using System.Collections.Generic;

namespace _3.SequenceInMatrix
{
    class SequenceInMatrix
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);

            // PrintMatrix(matrix);

            int longestSequence = FindLongestSequenceInMatrix(matrix);
            Console.WriteLine(longestSequence);
        }

        private static int FindLongestSequenceInMatrix(int[,] matrix)
        {
            int longest = 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // start check rows
            for (int row = 0; row < rows; row++)
            {
                int[] rowArr = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    rowArr[col] = matrix[row, col];
                }

                int currentSequenceLenght = FindLongestSequenceInArray(rowArr);
                if (currentSequenceLenght > longest)
                {
                    longest = currentSequenceLenght;
                }
            }
            // end check rows

            // start check cols
            for (int col = 0; col < cols; col++)
            {
                int[] colArr = new int[rows];
                for (int row = 0; row < rows; row++)
                {
                    colArr[row] = matrix[row, col];
                }

                int currentSequenceLenght = FindLongestSequenceInArray(colArr);
                if (currentSequenceLenght > longest)
                {
                    longest = currentSequenceLenght;
                }
            }
            // end check cols

            // start check left diagonals
            List<List<int>> leftDiagonals = ExtractLeftDiagonals(matrix);
            foreach (var diagonal in leftDiagonals)
            {
                int currentSequenceLenght = FindLongestSequenceInArray(diagonal.ToArray());
                if (currentSequenceLenght > longest)
                {
                    longest = currentSequenceLenght;
                }
            }
            // end check left diagonals

            // start check right diagonals
            List<List<int>> rightDiagonals = ExtractRightDiagonals(matrix);
            foreach (var diagonal in rightDiagonals)
            {
                int currentSequenceLenght = FindLongestSequenceInArray(diagonal.ToArray());
                if (currentSequenceLenght > longest)
                {
                    longest = currentSequenceLenght;
                }
            }
            // end check right diagonals

            return longest;
        }

        private static List<List<int>> ExtractRightDiagonals(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            List<List<int>> diagonals = new List<List<int>>();

            for (int i = 0; i < cols; i++)
            {
                int col = i;
                List<int> diagonal = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    if (col < 0)
                    {
                        break;
                    }
                    diagonal.Add(matrix[row, col]);
                    col--;
                }

                diagonals.Add(diagonal);
            }

            for (int i = 1; i < rows; i++)
            {
                int row = i;
                List<int> diagonal = new List<int>();

                for (int col = cols - 1; col >= 0; col--)
                {
                    if (row >= rows)
                    {
                        break;
                    }
                    diagonal.Add(matrix[row, col]);
                    row++;
                }

                diagonals.Add(diagonal);
            }

            return diagonals;
        }

        private static List<List<int>> ExtractLeftDiagonals(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            List<List<int>> diagonals = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                int row = i;
                List<int> diagonal = new List<int>();

                for (int col = 0; col < cols; col++)
                {
                    if (row >= rows)
                    {
                        break;
                    }
                    diagonal.Add(matrix[row, col]);
                    row++;
                }

                diagonals.Add(diagonal);
            }

            for (int i = 1; i < cols; i++)
            {
                int col = i;
                List<int> diagonal = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    if (col >= cols)
                    {
                        break;
                    }
                    diagonal.Add(matrix[row, col]);
                    col++;
                }

                diagonals.Add(diagonal);
            }

            return diagonals;
        }

        private static int FindLongestSequenceInArray(int[] array)
        {
            int n = array.Length;
            int[] sequences = new int[n];
            int longestSequenceLength = 0;

            for (int i = 1; i < n; i++)
            {

                if (array[i] == array[i - 1])
                {
                    sequences[i] += sequences[i - 1] + 1;
                    if (sequences[i] > longestSequenceLength)
                    {
                        longestSequenceLength = sequences[i];
                    }
                }
            }

            return longestSequenceLength + 1;
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
