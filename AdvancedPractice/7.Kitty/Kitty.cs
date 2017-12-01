using System;
using System.Linq;

namespace _7.Kitty
{
    class Kitty
    {
        static void Main()
        {
            char[] path = Console.ReadLine().ToArray();

            int[] moves = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int position = 0;
            int food = 0;
            int souls = 0;
            int deadlocks = 0;

            for (int i = 0; i <= moves.Length; i++)
            {
                char cell = path[position];

                if (cell == '@')
                {
                    souls++;
                    path[position] = '-';
                }
                else if (cell == '*')
                {
                    food++;
                    path[position] = '-';
                }
                else if (cell == 'x')
                {
                    if (position % 2 == 0)
                    {
                        if (souls <= 0)
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!");
                            Console.WriteLine("Jumps before deadlock: {0}", i);
                            return;
                        }
                        else
                        {
                            souls--;
                            path[position] = '@';
                        }
                    }
                    else
                    {
                        if (food <= 0)
                        {
                            Console.WriteLine("You are deadlocked, you greedy kitty!");
                            Console.WriteLine("Jumps before deadlock: {0}", i);
                            return;
                        }
                        else
                        {
                            food--;
                            path[position] = '*';
                        }
                    }

                    deadlocks++;
                }
                else
                {
                    // do nothing
                }

                if (i < moves.Length)
                {
                    position = UpdatePosition(position, moves[i], path.Length);
                }
            }

            Console.WriteLine("Coder souls collected: {0}", souls);
            Console.WriteLine("Food collected: {0}", food);
            Console.WriteLine("Deadlocks: {0}", deadlocks);
        }

        private static int UpdatePosition(int position, int move, int arrLength)
        {
            move = move % arrLength;

            position += move;
            if (position >= arrLength)
            {
                position -= arrLength;
            }
            if (position < 0)
            {
                position += arrLength;
            }

            return position;
        }
    }
}