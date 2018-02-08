using System;
using System.Collections.Generic;

namespace _5Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split(' '));
            int count = int.Parse(Console.ReadLine());
            while (kids.Count>1)
            {
                
                for (int i = 1; i < count; i++)
                {
                    string curentKid = kids.Dequeue();
                    kids.Enqueue(curentKid);
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
