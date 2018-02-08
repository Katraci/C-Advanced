using System;
using System.Linq;

namespace Problem_1_Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = n => Console.WriteLine(n);
            Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
        }
    }
}
