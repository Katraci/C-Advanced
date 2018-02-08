using System;

namespace Problem_8_Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long f0 = 1;
            long f1 = 1;
            for (int i = 0; i < n - 2; i++)
            {
                var f2 = f0 + f1;
                f0 = f1;
                f1 = f2;
            }
            Console.WriteLine(f1);
        }
    }
}
