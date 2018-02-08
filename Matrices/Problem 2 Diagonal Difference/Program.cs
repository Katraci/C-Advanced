using System;
using System.Linq;

namespace Problem_2_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            long lines = long.Parse(Console.ReadLine());
            long[,] matrix = new long[lines, lines];
            for (int i = 0; i < lines; i++)
            {
               long[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int j = 0; j < lines; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            long firstDiagonal = 0;
            long secondDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i==j)
                    {
                        firstDiagonal += matrix[i, j];
                    }
                    if (j==matrix.GetLength(1)-1-i)
                    {
                        secondDiagonal += matrix[i, j];
                    }
                }
            }
            long result = Math.Abs(firstDiagonal - secondDiagonal);
            Console.WriteLine(result);
        }
    }
}
