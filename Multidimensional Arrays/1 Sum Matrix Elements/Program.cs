using System;
using System.Linq;

namespace _1_Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            int[,] matrix = new int[row,col];
            int sum = 0;
            for (int i = 0; i < row; i++)
            {
                int[] input= Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                    sum += input[j];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
