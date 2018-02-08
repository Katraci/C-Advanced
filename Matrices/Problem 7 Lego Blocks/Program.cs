using System;
using System.Linq;

namespace Problem_7_Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[][] first = new int[lines][];
            int[][] second = new int[lines][];
            for (int i = 0; i < lines; i++)
            {
                first[i]= Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            for (int i = 0; i < lines; i++)
            {
                second[i]=Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            bool token = true;
            int counter = first[0].Length+second[0].Length;
            int cells=0;
            for (int i = 0; i < lines; i++)
            {
                if (counter!= first[i].Length + second[i].Length)
                {
                    token = false;
                }
                cells += first[i].Length + second[i].Length;
            }
            if (token)
            {
                for (int i = 0; i < lines; i++)
                {
                    Console.WriteLine("["+String.Join(", ",first[i])+", "+ String.Join(", ", second[i].Reverse())+"]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cells}");
            }
        }
    }
}
