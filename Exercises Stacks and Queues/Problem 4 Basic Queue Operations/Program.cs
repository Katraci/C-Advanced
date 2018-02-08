using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToEnter = arr[0];
            int elementsToRemove = arr[1];
            int elementToCheck = arr[2];
            int[] input= Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers=new Queue<int>();
            for (int i = 0; i < elementsToEnter; i++)
            {
                if (i >= input.Length)
                {
                    break;
                }
                else
                {
                    numbers.Enqueue(input[i]);
                }
            }

            if (elementsToRemove>=numbers.Count)
            {
                numbers.Clear();
            }
            else
            {
                for (int i = 0; i < elementsToRemove; i++)
                {
                    numbers.Dequeue();
                }
            }

            if (numbers.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count==0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}
