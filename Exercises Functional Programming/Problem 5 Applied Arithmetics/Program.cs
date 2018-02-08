using System;
using System.Linq;

namespace Problem_5_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command!="end")
            {
                numbers = Change(numbers, command);
                command = Console.ReadLine();
            }
        }

        private static int[] Change(int[] numbers, string command)
        {
            switch (command)
            {
                case "add": return numbers.Select(n => n + 1).ToArray();
                case "multiply":return numbers.Select(n => n * 2).ToArray();
                case "subtract":return numbers.Select(n => n - 1).ToArray();
                case "print": PrinArray(numbers); return numbers;
                default:
                    return numbers;
            }
        }

        private static void PrinArray(int[] numbers)
        {
            Console.WriteLine(string.Join(" " ,numbers));
        }
    }
}
