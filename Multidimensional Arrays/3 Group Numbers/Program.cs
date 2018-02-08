using System;
using System.Linq;

namespace _3_Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            int[][] sorted = new int[3][];
            sorted[0] = input.Where(n => n % 3 == 0).ToArray();
            sorted[1]= input.Where(n => n % 3 == 1||n%3==-1).ToArray();
            sorted[2]= input.Where(n => n % 3 == 2||n%3==-2).ToArray();
            foreach (var row in sorted)
            {
                foreach (var col in row)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
