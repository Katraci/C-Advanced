using System;
using System.Linq;

namespace Problem_4_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
           Predicate<long> odd=(long n) => n % 2 == 1||n%2==-1;
           Predicate<long> even = (long n) => n % 2 == 0;
            long[] range = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).OrderBy(n=>n).ToArray();
            string command = Console.ReadLine();
            for (long i = range[0]; i <= range[1]; i++)
            {
                if (command=="odd"&&odd(i))
                {
                    Console.Write(i + " ");
                }
                if (command=="even"&&even(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
