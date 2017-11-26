using System;

namespace _7.BishopPathFinder
{
    class BishopPathFinder
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[,] matrix = new int[rows, cols];

            FillTheMatrixDiagonaly(matrix);

            //PrintMatrix(matrix);

            int n = int.Parse(Console.ReadLine());

            int currentRowIndex = rows - 1;
            int currentColIndex = 0;

            int previousRowIndex = currentRowIndex;
            int previousColIndex = currentColIndex;

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                string direction = commandArgs[0];
                int moves = int.Parse(commandArgs[1]);
                int move = 1;

                while (true)
                {
                    if (currentRowIndex < 0 || currentRowIndex >= rows || currentColIndex < 0 || currentColIndex >= cols)
                    {
                        currentRowIndex = previousRowIndex;
                        currentColIndex = previousColIndex;
                        break;
                    }

                    previousRowIndex = currentRowIndex;
                    previousColIndex = currentColIndex;

                    sum += matrix[currentRowIndex, currentColIndex];
                    matrix[currentRowIndex, currentColIndex] = 0;

                    if (move >= moves)
                    {
                        break;
                    }

                    if (direction == "RU" || direction == "UR")
                    {
                        currentRowIndex--;
                        currentColIndex++;
                    }
                    else if (direction == "LU" || direction == "UL")
                    {
                        currentRowIndex--;
                        currentColIndex--;
                    }
                    else if (direction == "DL" || direction == "LD")
                    {
                        currentRowIndex++;
                        currentColIndex--;
                    }
                    else if (direction == "DR" || direction == "RD")
                    {
                        currentRowIndex++;
                        currentColIndex++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid direction.");
                    }

                    move++;
                }

            }

            Console.WriteLine(sum);
        }

        private static void FillTheMatrixDiagonaly(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int diagonalCounter = 1;

            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                int row = rows - 1 - i;
                int col = 0;
                while (true)
                {
                    if (row >= rows || col >= cols)
                    {
                        break;
                    }
                    matrix[row, col] = counter;
                    row++;
                    col++;
                }
                counter += 3;
                diagonalCounter++;
            }

            for (int i = 0; i < cols; i++)
            {
                int row = 0;
                int col = i + 1;

                while (true)
                {
                    if (row >= rows || col >= cols)
                    {
                        break;
                    }
                    matrix[row, col] = counter;
                    row++;
                    col++;
                }
                counter += 3;
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
