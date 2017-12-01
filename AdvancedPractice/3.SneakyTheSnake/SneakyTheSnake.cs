using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SneakyTheSnake
{
    class SneakyTheSnake
    {
        static char[,] matrix;
        static int entranceRow;
        static int entranceCol;
        static int rows;
        static int cols;

        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split('x').Select(int.Parse).ToArray();

            rows = dimensions[0];
            cols = dimensions[1];

            FillMatrix();

            int snakeLength = 3;
            int currentRow = entranceRow;
            int currentCol = entranceCol;
            int move = 1;

            string[] directions = Console.ReadLine().Split(',');

            for (int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i];

                
                if (snakeLength <= 0)
                {
                    Console.WriteLine("Sneaky is going to starve at [{0},{1}]", currentRow, currentCol);
                    return;
                }

                if (direction == "s") // down
                {
                    currentRow++;
                    if (currentRow >= rows)
                    {
                        Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", snakeLength);
                        return;
                    }
                }
                else if (direction == "w") // up
                {
                    currentRow--;
                }
                else if (direction == "a") // left
                {
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = cols - 1;
                    }
                }
                else if (direction == "d") // right
                {
                    currentCol++;
                    if (currentCol >= cols)
                    {
                        currentCol = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid direction");
                }

                char field = matrix[currentRow, currentCol];

                if (field == '%')
                {
                    Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", currentRow, currentCol);
                    return;
                }
                if (field == '@')
                {
                    snakeLength++;
                    matrix[currentRow, currentCol] = '-';
                }
                if (move % 5 == 0)
                {
                    snakeLength--;
                }

                move++;
            }

            if (currentRow == entranceRow && currentCol == entranceCol)
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", snakeLength);
            }
            else
            {
                Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", currentRow, currentCol);
            }


        }

        private static void FillMatrix()
        {
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (inputRow[col] == 'e')
                    {
                        entranceRow = row;
                        entranceCol = col;
                    }
                }
            }
        }

        private static void PrintMatix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}