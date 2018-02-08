using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3_Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Stack<int> numbers=new Stack<int>();
            Stack<int> maxValues=new Stack<int>();
            int curentMax=int.MinValue;
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (input[0]==1)
                {
                    numbers.Push(input[1]);
                    if (input[1]>=curentMax)
                    {
                        curentMax = input[1];
                        maxValues.Push(curentMax);
                    }
                }

                if (input[0]==2)
                {
                    if (numbers.Pop()==curentMax)
                    {
                        maxValues.Pop();
                        if (maxValues.Count>0)
                        {
                            curentMax = maxValues.Peek();
                        }
                        else
                        {
                            curentMax = int.MinValue;
                        }
                    }
                }

                if (input[0]==3)
                {
                    Console.WriteLine(maxValues.Peek());
                }
            }
        }
    }
}
