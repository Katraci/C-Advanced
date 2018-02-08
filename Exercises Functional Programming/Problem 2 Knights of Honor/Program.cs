using System;
using System.Linq;

namespace Problem_2_Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = n => Console.WriteLine("Sir "+n);
            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
        }
    }
}
