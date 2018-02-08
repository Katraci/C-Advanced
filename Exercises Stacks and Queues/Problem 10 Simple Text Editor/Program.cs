using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_10_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text=new StringBuilder();
            int operation = int.Parse(Console.ReadLine());
            Stack<string> stackOperation=new Stack<string>();
            for (int i = 0; i < operation; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                switch (command[0])
                {
                    case "1":
                        stackOperation.Push(text.ToString());
                        text.Append(command[1]);
                        break;
                    case "2":
                        stackOperation.Push(text.ToString());
                        int removeCount = int.Parse(command[1]);
                        int startIndex = text.Length - removeCount;
                        text.Remove(startIndex,removeCount );
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1])-1]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(stackOperation.Pop());
                        break;
                }
            }
        }
    }
}
