using System;
using System.Collections.Generic;

namespace _4Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    indexes.Push(i);
                }
                if (input[i]==')')
                {
                    int begin = indexes.Pop();
                    int end = i+1 - begin;
                    Console.WriteLine(input.Substring(begin,end));
                }
            }
        }
    }
}
