using System;
using System.Linq;

namespace Problem_3_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber=n=>n.Min();
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(minNumber(numbers));
        }
    }
}
