using System;
using System.Linq;

namespace Problem_6_Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int filter = int.Parse(Console.ReadLine());
            numbers = numbers.Reverse().Where(n => n % filter != 0).ToArray();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
