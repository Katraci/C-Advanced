using System;
using System.Collections.Generic;
using System.Linq;

namespace _2Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> result = new Stack<string>(Console.ReadLine().Split(' ').Reverse());
            while (result.Count>1)
            {
                int firstNumber = int.Parse(result.Pop());
                string operant = result.Pop();
                int secondNumber = int.Parse(result.Pop());
                if (operant=="+")
                {
                    result.Push(Convert.ToString(firstNumber + secondNumber));
                }
                else
                {
                    result.Push(Convert.ToString(firstNumber - secondNumber));
                }
            }
            Console.WriteLine(result.Pop());
        }
    }
}
