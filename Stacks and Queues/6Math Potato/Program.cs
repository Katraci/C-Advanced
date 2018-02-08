using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6Math_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split(' '));
            int count = int.Parse(Console.ReadLine());
            int counter = 1;
            while (kids.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    string curentKid = kids.Dequeue();
                    kids.Enqueue(curentKid);
                }
                if (IsPrime(counter))
                {
                    Console.WriteLine($"Prime {kids.Peek()}");
                }
                else
                {
                        Console.WriteLine($"Removed {kids.Dequeue()}");
                }
                counter++;
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }

        private static bool IsPrime(int counter)
        {
            if (counter == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; i < counter; i++)
                {
                    if (counter % i == 0)
                    {
                        break;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }

        }
    }
}
