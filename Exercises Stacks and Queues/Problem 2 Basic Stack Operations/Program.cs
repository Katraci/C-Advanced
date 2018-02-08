using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            int elementsToPush = numbers.Pop();
            int elementsToPop = numbers.Pop();
            int numberForCheck = numbers.Pop();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> elemets = new Stack<int>();
            for (int i = 0; i < elementsToPush; i++)
            {
                if (i>=input.Length)
                {
                    break;
                }
                else
                {
                    elemets.Push(input[i]);
                }
            }
            if (elementsToPop>=elemets.Count)
            {
                elemets.Clear();
            }
            else
            {
                for (int i = 0; i < elementsToPop; i++)
                {
                    elemets.Pop();
                }
            }
            if (elemets.Contains(numberForCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (elemets.Count>0)
                {
                    Console.WriteLine(elemets.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
