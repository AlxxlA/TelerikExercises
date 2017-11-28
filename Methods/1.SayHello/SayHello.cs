using System;

namespace _1.SayHello
{
    class SayHello
    {
        static void Main()
        {
            PrintName();
        }

        private static void PrintName()
        {
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}