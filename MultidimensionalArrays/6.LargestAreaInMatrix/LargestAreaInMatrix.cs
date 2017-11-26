using System;
using System.Collections.Generic;

namespace _6.LargestAreaInMatrix
{
    class LargestAreaInMatrix
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);

            int count = DFS(matrix, matrix[0, 0]);

            Console.WriteLine(count);

            PrintMatrix(matrix);

            string s = "asdsad";
            

            
        }

        private static int DFS(int[,] matrix, int previousElement, int row = 0, int col = 0, int count = 0, HashSet<Position> visited = null)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                return count;
            }
            int currentElement = matrix[row, col];
            if (currentElement != previousElement)
            {
                return count;
            }

            Position currentPosition = new Position(row, col);
            if (visited == null)
            {
                visited = new HashSet<Position>();
            }
            if (visited.Contains(currentPosition))
            {
                return count;
            }
            //visited.Add(currentPosition);

            count++;

            for (int i = row; i < rows; i++)
            {
                for (int j = col; j < cols; j++)
                {
                    currentElement = matrix[i, j];
                    visited.Add(new Position(i,j));
                    DFS(matrix, currentElement, i - 1, j, count, visited);
                    DFS(matrix, currentElement, i + 1, j, count, visited);
                    DFS(matrix, currentElement, i, j - 1, count, visited);
                    DFS(matrix, currentElement, i, j + 1, count, visited);
                }
            }
            //DFS(matrix, currentElement, row - 1, col, count, visited);
            //DFS(matrix, currentElement, row + 1, col, count, visited);
            //DFS(matrix, currentElement, row, col - 1, count, visited);
            //DFS(matrix, currentElement, row, col + 1, count, visited);




            return count;

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

    struct Position
    {

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
