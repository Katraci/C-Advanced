using System;
using System.Linq;

namespace _2_Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            int[,] matrix = new int[row, col];
            int maxSum = int.MinValue;
            int[,] maxValues = new int[2, 2];
            for (int i = 0; i < row; i++)
            {
                int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < row-1; i++)
            {
                for (int j = 0; j < col-1; j++)
                {
                    int curentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (curentSum>maxSum)
                    {
                        maxValues[0, 0] = matrix[i, j];
                        maxValues[0, 1] = matrix[i, j + 1];
                        maxValues[1, 0] = matrix[i + 1, j];
                        maxValues[1, 1] = matrix[i + 1, j + 1];
                        maxSum = curentSum;
                    }
                }
            }
            Console.WriteLine($"{maxValues[0, 0]} {maxValues[0, 1]}");
            Console.WriteLine($"{maxValues[1, 0]} {maxValues[1, 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
