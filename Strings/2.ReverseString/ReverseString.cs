using System;
using System.Linq;

namespace _2.ReverseString
{
    class ReverseString
    {
        static void Main()
        {
            string reversed = new string(Console.ReadLine().Reverse().ToArray());
            Console.WriteLine(reversed);
        }
    }
}