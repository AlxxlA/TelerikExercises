using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Porcupines
{
    abstract class Animal
    {
        public Animal(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Score = 0;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Score { get; set; }

        public abstract void MakeAMove(int[][] matrix, string direction, int steps, Animal anotherAnimal);
    }

    class Rabbit : Animal
    {
        public Rabbit(int row, int col) : base(row, col)
        {
        }

        public override void MakeAMove(int[][] matrix, string direction, int steps, Animal anotherAnimal)
        {
            this.Score += matrix[this.Row][this.Col];
            matrix[this.Row][this.Col] = 0;

            int currentCols = matrix[this.Row].GetLength(0);
            int rows = matrix.GetLength(0);

            if (direction == "R")
            {
                steps %= currentCols;
                int targetCol = this.Col + steps;
                if (targetCol >= currentCols)
                {
                    targetCol -= currentCols;
                }
                if (this.Row == anotherAnimal.Row && targetCol == anotherAnimal.Col)
                {
                    targetCol -= 1;
                    if (targetCol < 0)
                    {
                        targetCol += currentCols;
                    }
                }

                this.Col = targetCol;
            }
            else if (direction == "L")
            {
                steps %= currentCols;
                int targetCol = this.Col - steps;
                if (targetCol < 0)
                {
                    targetCol += currentCols;
                }
                if (this.Row == anotherAnimal.Row && targetCol == anotherAnimal.Col)
                {
                    targetCol += 1;
                    if (targetCol >= currentCols)
                    {
                        targetCol -= currentCols;
                    }
                }

                this.Col = targetCol;
            }
            else if (direction == "T")
            {
                int targetRow = this.Row;
                int makedSteps = 0;

                while (makedSteps < steps)
                {
                    try
                    {
                        targetRow--;
                        if (targetRow < 0)
                        {
                            targetRow = rows - 1;
                        }

                        int a = matrix[targetRow][this.Col]; // just check if it exist

                        makedSteps++;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (targetRow == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                {
                    while (true)
                    {
                        try
                        {
                            targetRow++;
                            if (targetRow >= rows)
                            {
                                targetRow = 0;
                            }

                            int a = matrix[targetRow][this.Col]; // just check if it exist

                            break;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                this.Row = targetRow;
            }
            else if (direction == "B")
            {
                int targetRow = this.Row;
                int makedSteps = 0;

                while (makedSteps < steps)
                {
                    try
                    {
                        targetRow++;
                        if (targetRow >= rows)
                        {
                            targetRow = 0;
                        }

                        int a = matrix[targetRow][this.Col]; // just check if it exist

                        makedSteps++;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (targetRow == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                {
                    while (true)
                    {
                        try
                        {
                            targetRow--;
                            if (targetRow < 0)
                            {
                                targetRow = rows - 1;
                            }

                            int a = matrix[targetRow][this.Col]; // just check if it exist

                            break;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                this.Row = targetRow;
            }
            else
            {
                // invalid direction
            }

            this.Score += matrix[this.Row][this.Col];
            matrix[this.Row][this.Col] = 0;
        }
    }

    class Porcupine : Animal
    {
        public Porcupine(int row, int col) : base(row, col)
        {
        }

        public override void MakeAMove(int[][] matrix, string direction, int steps, Animal anotherAnimal)
        {
            this.Score += matrix[this.Row][this.Col];
            matrix[this.Row][this.Col] = 0;

            int currentCols = matrix[this.Row].GetLength(0);
            int rows = matrix.GetLength(0);

            if (direction == "R")
            {
                steps %= currentCols;
                int targetCol = this.Col + steps;
                if (targetCol >= currentCols)
                {
                    targetCol -= currentCols;
                }
                if (this.Row == anotherAnimal.Row && targetCol == anotherAnimal.Col)
                {
                    targetCol -= 1;
                    if (targetCol < 0)
                    {
                        targetCol += currentCols;
                    }
                }

                while (this.Col != targetCol)
                {
                    this.Col++;
                    if (this.Col >= currentCols)
                    {
                        this.Col = 0;
                    }
                    if (this.Row == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                    {
                        this.Col--;
                        if (this.Col < 0)
                        {
                            this.Col = rows - 1;
                        }
                        break;
                    }
                    this.Score += matrix[this.Row][this.Col];
                    matrix[this.Row][this.Col] = 0;
                }
            }
            else if (direction == "L")
            {
                steps %= currentCols;
                int targetCol = this.Col - steps;
                if (targetCol < 0)
                {
                    targetCol += currentCols;
                }
                if (this.Row == anotherAnimal.Row && targetCol == anotherAnimal.Col)
                {
                    targetCol += 1;
                    if (targetCol >= currentCols)
                    {
                        targetCol -= currentCols;
                    }
                }

                while (this.Col != targetCol)
                {
                    this.Col--;
                    if (this.Col < 0)
                    {
                        this.Col = currentCols - 1;
                    }
                    if (this.Row == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                    {
                        this.Col++;
                        if (this.Col >= currentCols)
                        {
                            this.Col = 0;
                        }
                        break;
                    }
                    this.Score += matrix[this.Row][this.Col];
                    matrix[this.Row][this.Col] = 0;
                }
            }
            else if (direction == "T")
            {
                int targetRow = this.Row;
                int makedSteps = 0;

                while (makedSteps < steps)
                {
                    try
                    {
                        targetRow--;
                        if (targetRow < 0)
                        {
                            targetRow = rows - 1;
                        }

                        int a = matrix[targetRow][this.Col]; // just check if it exist

                        makedSteps++;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (targetRow == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                {
                    while (true)
                    {
                        try
                        {
                            targetRow++;
                            if (targetRow >= rows)
                            {
                                targetRow = 0;
                            }

                            int a = matrix[targetRow][this.Col]; // just check if it exist

                            break;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                while (this.Row != targetRow)
                {
                    try
                    {
                        this.Row--;
                        if (this.Row < 0)
                        {
                            this.Row = rows - 1;
                        }
                        if (this.Row == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                        {
                            while (true)
                            {
                                this.Row++;
                                if (this.Row >= rows)
                                {
                                    this.Row = 0;
                                }
                                int cols = matrix[this.Row].GetLength(0);
                                if (this.Col < cols)
                                {
                                    break;
                                }
                            }

                            return;
                        }
                        int a = matrix[this.Row][this.Col]; // just check if it exist

                        this.Score += a;
                        matrix[this.Row][this.Col] = 0;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else if (direction == "B")
            {
                int targetRow = this.Row;
                int makedSteps = 0;

                while (makedSteps < steps)
                {
                    try
                    {
                        targetRow++;
                        if (targetRow >= rows)
                        {
                            targetRow = 0;
                        }

                        int a = matrix[targetRow][this.Col]; // just check if it exist

                        makedSteps++;
                    }
                    catch (Exception)
                    {
                    }
                }

                if (targetRow == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                {
                    while (true)
                    {
                        try
                        {
                            targetRow--;
                            if (targetRow < 0)
                            {
                                targetRow = rows - 1;
                            }

                            int a = matrix[targetRow][this.Col]; // just check if it exist

                            break;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                while (this.Row != targetRow)
                {
                    try
                    {
                        this.Row++;
                        if (this.Row >= rows)
                        {
                            this.Row = 0;
                        }
                        if (this.Row == anotherAnimal.Row && this.Col == anotherAnimal.Col)
                        {
                            while (true)
                            {
                                this.Row--;
                                if (this.Row < 0)
                                {
                                    this.Row = rows - 1;
                                }
                                int cols = matrix[this.Row].GetLength(0);
                                if (this.Col < cols)
                                {
                                    break;
                                }
                            }

                            break;
                        }
                        int a = matrix[this.Row][this.Col]; // just check if it exist

                        this.Score += a;
                        matrix[this.Row][this.Col] = 0;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                // invalid direction
            }
        }
    }

    class Porcupines
    {
        static void Main()
        {
            int baseColCount = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];
            FillMatrix(matrix, baseColCount);
            //PrintMatrix(matrix);

            int[] porcupinePosition = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] rabbitPosition = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var porcupine = new Porcupine(porcupinePosition[0], porcupinePosition[1]);
            var rabbit = new Rabbit(rabbitPosition[0], rabbitPosition[1]);


            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split();

                string animal = commandArgs[0];
                string direction = commandArgs[1];
                int steps = int.Parse(commandArgs[2]);

                if (animal == "P")
                {
                    porcupine.MakeAMove(matrix, direction, steps, rabbit);
                }
                else if (animal == "R")
                {
                    rabbit.MakeAMove(matrix, direction, steps, porcupine);
                }
                else
                {
                    // animal do not exist
                }

                command = Console.ReadLine();
            }

            if (rabbit.Score > porcupine.Score)
            {
                Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.", rabbit.Score, porcupine.Score);
            }
            else if (porcupine.Score > rabbit.Score)
            {
                Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.", porcupine.Score, rabbit.Score);
            }
            else
            {
                Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabbit.Score);
            }
        }

        private static void FillMatrix(int[][] matrix, int baseColCount)
        {
            int rows = matrix.GetLength(0);
            int firstHalf = rows / 2;
            int secondHalf = rows - firstHalf;

            int colCount = baseColCount;
            int colProduct = 1;
            for (int i = 0; i < firstHalf; i++)
            {
                colCount = colProduct * baseColCount;
                colProduct++;
                matrix[i] = new int[colCount];
                int value = i + 1;
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i][j] = value;
                    value += (i + 1);
                }
            }

            if (firstHalf == secondHalf)
            {
                colProduct--;
            }
            else
            {
                secondHalf--;
            }

            for (int i = secondHalf; i < rows; i++)
            {
                int value = i + 1;
                colCount = colProduct * baseColCount;
                colProduct--;
                matrix[i] = new int[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i][j] = value;
                    value += (i + 1);
                }
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}