using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int rows;
    static int cols;
    static bool[,] used;
    static int greatestArea;
    static int currentArea;

    static int[,] matrix;
    static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = token[0];
        cols = token[1];

        matrix = new int[rows, cols];
        used = new bool[rows, cols];

        FillMatrix();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int targetValue = matrix[row, col];
                if (!used[row, col])
                {
                    currentArea = 0;

                    Stack<int> rowStack = new Stack<int>();
                    Stack<int> colStack = new Stack<int>();

                    rowStack.Push(row);
                    colStack.Push(col);

                    while (rowStack.Count > 0)
                    {
                        int currentRow = rowStack.Pop();
                        int currentCol = colStack.Pop();

                        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols)
                        {
                            continue;
                        }
                        if (matrix[currentRow, currentCol] != targetValue)
                        {
                            continue;
                        }
                        if (used[currentRow, currentCol])
                        {
                            continue;
                        }

                        used[currentRow, currentCol] = true;
                        currentArea++;

                        if (greatestArea < currentArea)
                        {
                            greatestArea = currentArea;
                        }

                        if (currentRow + 1 < rows)
                        {
                            rowStack.Push(currentRow + 1);
                            colStack.Push(currentCol);
                        }
                        if (currentRow - 1 >= 0)
                        {
                            rowStack.Push(currentRow - 1);
                            colStack.Push(currentCol);
                        }
                        if (currentCol - 1 >= 0)
                        {
                            rowStack.Push(currentRow);
                            colStack.Push(currentCol - 1);
                        }
                        if (currentCol + 1 < cols)
                        {
                            rowStack.Push(currentRow);
                            colStack.Push(currentCol + 1);
                        }
                    }
                }
            }

        }

        Console.WriteLine(greatestArea);
    }

    private static void FillMatrix()
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
}