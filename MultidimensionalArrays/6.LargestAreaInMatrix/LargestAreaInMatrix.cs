using System;
using System.Collections.Generic;
using System.Linq;

class State
{
    public State(int row, int col, int value)
    {
        this.Row = row;
        this.Col = col;
        this.Value = value;
    }

    public int Row { get; set; }
    public int Col { get; set; }
    public int Value { get; set; }
}
class Program
{
    static int rows;
    static int cols;
    static bool[,] used;
    static int greatestArea;
    static int currentArea;

    static int[][] matrix;
    static void Main(string[] args)
    {
        var token = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = token[0];
        cols = token[1];

        var matrix = new int[rows][];
        used = new bool[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (!used[row, col])
                {
                    currentArea = 0;
                    int value = matrix[row][col];

                    Stack<State> stack = new Stack<State>();

                    stack.Push(new State(row, col, value));

                    while (stack.Count > 0)
                    {
                        var state = stack.Pop();

                        if (state.Row < 0 || state.Row >= rows || state.Col < 0 || state.Col >= cols)
                        {
                            continue;
                        }
                        if (matrix[state.Row][state.Col] != state.Value)
                        {
                            continue;
                        }
                        if (used[state.Row, state.Col])
                        {
                            continue;
                        }

                        used[state.Row, state.Col] = true;
                        currentArea++;
                        greatestArea = Math.Max(greatestArea, currentArea);

                        stack.Push(new State(state.Row + 1, state.Col, state.Value));
                        stack.Push(new State(state.Row - 1, state.Col, state.Value));
                        stack.Push(new State(state.Row, state.Col - 1, state.Value));
                        stack.Push(new State(state.Row, state.Col + 1, state.Value));
                    }
                }
            }

        }

        Console.WriteLine(greatestArea);
    }
}