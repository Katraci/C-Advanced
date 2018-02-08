using System;
using System.Collections.Generic;

namespace Problem_9_Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(0);
            fibonacci.Push(1);
            for (int i = 0; i < n-1; i++)
            {
                long number = fibonacci.Pop();
                long number2 = fibonacci.Peek() + number;
                fibonacci.Push(number);
                fibonacci.Push(number2);
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
