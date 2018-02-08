using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            Queue<string> cars=new Queue<string>();
            string input = Console.ReadLine();
            int counter = 0;
            while (input!="end")
            {
                if (input=="green")
                {
                    for (int i = 0; i < greenDuration; i++)
                    {
                        if (cars.Count>0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    if (input=="end")
                    {
                        break;
                    }
                    else
                    {
                        cars.Enqueue(input);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
