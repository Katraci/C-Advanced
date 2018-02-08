using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5_Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
           long input = long.Parse(Console.ReadLine());
            Queue<long> numbers=new Queue<long>();
            numbers.Enqueue(input);
            Queue<long> next=new Queue<long>();
            next.Enqueue(input);
            while (numbers.Count<=50)
            {
                long number = next.Dequeue();
                numbers.Enqueue(number + 1);
                if (numbers.Count == 50)
                {
                    break;
                }
                next.Enqueue(number + 1);
                numbers.Enqueue(2 * number + 1);
                if (numbers.Count == 50)
                {
                    break;
                }
                next.Enqueue(2 * number + 1);
                numbers.Enqueue(number + 2);
                next.Enqueue(number + 2);
                if (numbers.Count == 50)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
