using System;
using System.Linq;

namespace Problem_1_Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new string[rowAndCol[0], rowAndCol[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (Convert.ToChar(i + 97)).ToString() + (Convert.ToChar(i +j+ 97)).ToString() + (Convert.ToChar(i + 97)).ToString();
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
