using System;
using System.Linq;
using System.Numerics;

namespace _6.BitShiftMatrix
{
    class BitShiftMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            BigInteger[,] matrix = new BigInteger[rows, cols];

            FillTheMatrixDiagonaly(matrix);

            //PrintMatrix(matrix);

            int n = int.Parse(Console.ReadLine());
            decimal[] codes = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            int coeff = Math.Max(rows, cols);

            int currentRow = rows - 1;
            int currentCol = 0;

            BigInteger sum = 0;
           
            for (int i = 0; i < n; i++)
            {
                int targetRow = (int)codes[i] / coeff;
                int targetCol = (int)codes[i] % coeff;

                sum += MakeAMove(matrix, currentRow, currentCol, targetRow, targetCol);

                currentRow = targetRow;
                currentCol = targetCol;
            }
            
            Console.WriteLine(sum);
        }

        private static BigInteger MakeAMove(BigInteger[,] matrix, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            BigInteger sum = 0;

            if (currentCol >= targetCol)
            {
                for (int i = currentCol; i >= targetCol; i--)
                {
                    sum += matrix[currentRow, i];
                    matrix[currentRow, i] = 0;
                }
            }
            else
            {
                for (int i = currentCol; i <= targetCol; i++)
                {
                    sum += matrix[currentRow, i];
                    matrix[currentRow, i] = 0;
                }
            }

            currentCol = targetCol;

            if (currentRow >= targetRow)
            {
                for (int i = currentRow; i >= targetRow; i--)
                {
                    sum += matrix[i, currentCol];
                    matrix[i, currentCol] = 0;
                }
            }
            else
            {
                for (int i = currentRow; i <= targetRow; i++)
                {
                    sum += matrix[i, currentCol];
                    matrix[i, currentCol] = 0;
                }
            }

            currentRow = targetRow;

            return sum;
        }

        private static void FillTheMatrixDiagonaly(BigInteger[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            BigInteger counter = new BigInteger(1);

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
                counter *= 2;
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
                counter *= 2;
            }
        }

        private static void PrintMatrix(BigInteger[,] matrix)
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
