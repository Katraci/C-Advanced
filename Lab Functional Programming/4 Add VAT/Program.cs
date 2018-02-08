using System;
using System.Linq;

namespace _4_Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] prices = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).Select(x => x =x+(x*20 / 100)).ToArray();
            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
