using System;
using System.Collections.Generic;

namespace Problem_7_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> normal=new Stack<int>();
            Stack<int> curve=new Stack<int>();
            Stack<int> square=new Stack<int>();
            bool token = true;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':normal.Push(i);break;
                    case '{':curve.Push(i);break;
                    case '[':square.Push(i);break;
                    case ')':
                        if (normal.Count!=0)
                        {
                            if ((i-normal.Pop())%2!=1)
                            {
                                token = false;
                            }
                        }
                        else
                        {
                            token = false;
                        }
                        break;
                    case '}':
                        if (curve.Count!=0)
                        {
                            if ((i - curve.Pop()) % 2 != 1)
                            {
                                token = false;
                            }
                        }
                        else
                        {
                            token = false;
                        }
                        break;
                    case ']':
                        if (square.Count!=0)
                        {
                            if ((i - square.Pop()) % 2 != 1)
                            {
                                token = false;
                            }
                        }
                        else
                        {
                            token = false;
                        }
                        break;
                }

                if (!token)
                {
                    break;
                }
            }
              if (token)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
        }
    }
}
