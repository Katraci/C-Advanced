using System;
using System.Linq;

namespace Problem_4_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            int[,] matrix = new int[row, col];
            int maxSum = int.MinValue;
            int[] maxValuesCordinat = new int[2]; 
            for (int i = 0; i < row; i++)
            {
                int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < col - 2; j++)
                {
                    int curentSum = 0;
                    for (int l = 0; l < 3; l++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            curentSum += matrix[i + l, j + k];
                        }
                    }
                    if (curentSum > maxSum)
                    {
                        maxSum = curentSum;
                        maxValuesCordinat[0] = i;
                        maxValuesCordinat[1] = j;
                    }
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index1 = maxValuesCordinat[0] + i;
                    int index2 = maxValuesCordinat[1] + j;
                    Console.Write(matrix[index1, index2] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}