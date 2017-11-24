using System;

namespace _1.FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string fillType = Console.ReadLine();

            int[,] matrix = new int[n, n];

            if (fillType == "a" || fillType == "b")
            {
                FillMatrixByColumn(matrix, fillType);
            }
            else if (fillType == "c")
            {
                FillTheMatrixDiagonaly(matrix);
            }
            else if (fillType == "d")
            {
                FillMatrixSpirally(matrix);
            }
            else
            {
                Console.WriteLine("Undefined fill type");
            }

            PrintMatrix(matrix);
        }

        private static void FillMatrixSpirally(int[,] matrix)
        {
            int n = matrix.Length;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int row = 0;
            int col = 0;
            int counter = 1;
            string direction = "down";

            for (int i = 0; i < n; i++)
            {
                if (direction == "down")
                {
                    if (row >= rows || matrix[row, col] != 0)
                    {
                        direction = "right";
                        row--;
                        col++;
                        i--;
                        continue;
                    }

                    matrix[row, col] = counter;
                    counter++;
                    row++;
                }
                else if (direction == "right")
                {
                    if (col >= cols || matrix[row, col] != 0)
                    {
                        direction = "up";
                        col--;
                        row--;
                        i--;
                        continue;
                    }
                    matrix[row, col] = counter;
                    counter++;
                    col++;
                }
                else if (direction == "up")
                {
                    if (row < 0 || matrix[row, col] != 0)
                    {
                        direction = "left";
                        row++;
                        col--;
                        i--;
                        continue;
                    }

                    matrix[row, col] = counter;
                    counter++;
                    row--;
                }
                else if (direction == "left")
                {
                    if (col < 0 || matrix[row, col] != 0)
                    {
                        direction = "down";
                        col++;
                        row++;
                        i--;
                        continue;
                    }
                    matrix[row, col] = counter;
                    counter++;
                    col--;
                }
            }
        }

        private static void FillMatrixByColumn(int[,] matrix, string fillType)
        {
            int n = matrix.GetLength(0);
            int counter = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (fillType == "a")
                    {
                        matrix[j, i] = counter;
                    }
                    else if (fillType == "b")
                    {
                        if (i % 2 == 1)
                        {
                            int reversedColIndex = n - 1 - j;
                            matrix[reversedColIndex, i] = counter;
                        }
                        else
                        {
                            matrix[j, i] = counter;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Undefined fill type");
                    }

                    counter++;
                }
            }
        }

        private static void FillTheMatrixDiagonaly(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int diagonalCounter = 1;

            int counter = 1;

            for (int i = 0; i < n; i++)
            {
                int row = n - 1 - i;
                for (int col = 0; col < diagonalCounter; col++)
                {
                    matrix[row, col] = counter;
                    row++;
                    counter++;
                }

                diagonalCounter++;
            }


            for (int i = 0; i < n; i++)
            {
                diagonalCounter--;
                int row = 0;
                int col = i + 1;
                for (int j = 0; j < diagonalCounter - 1; j++)
                {
                    matrix[row, col] = counter;
                    counter++;
                    row++;
                    col++;
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