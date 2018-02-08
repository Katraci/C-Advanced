using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> binarNumber = new Stack<int>();
            if (number==0)
            {
                Console.WriteLine("0");
            }
            else
            {
                while (number > 0)
                {
                    binarNumber.Push(number % 2);
                    number /= 2;
                }
                int loop = binarNumber.Count();
                for (int i = 0; i < loop; i++)
                {
                    Console.Write(binarNumber.Pop());
                }
                Console.WriteLine();
            }
        }
    }
}
