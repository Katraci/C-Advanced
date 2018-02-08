using System;
using System.Collections.Generic;

namespace _1Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> reversed = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                reversed.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reversed.Pop());
            }
            Console.WriteLine();
        }
    }
}
