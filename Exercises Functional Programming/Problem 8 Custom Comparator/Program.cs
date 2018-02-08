using System;
using System.Linq;

namespace Problem_8_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .OrderByDescending(n => n % 2 == 0).ThenBy(n => n).ToArray();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
