using System;
using System.Linq;

namespace Problem_6_Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            char[,] matrix = new char[row, col];
            char[] text = Console.ReadLine().ToCharArray();
            int[] shot= Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index = 0;
            for (int i = matrix.GetLength(0)-1; i >= 0; i--)
            {
                if (matrix.GetLength(0)%2!=i%2)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = text[index];
                        index++;
                        if (index >= text.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        matrix[i, k] = text[index];
                        index++;
                        if (index >= text.Length)
                        {
                            index = 0;
                        }
                    }
                }

            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (IsInRange(shot, i, j))
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i,j]==' ')
                    {
                        int indexToMove = i;
                        for (int k = indexToMove; k >=1; k--)
                        {
                            char token = matrix[k, j];
                            matrix[k, j] = matrix[k - 1, j];
                            matrix[k - 1, j] = token;
                        }
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInRange(int[] shot, int i, int j)
        {
            int indexRow = shot[0];
            int indexCol = shot[1];
            int radius = shot[2];
            var distance = Math.Sqrt((i - indexRow) * (i - indexRow) + (j - indexCol) * (j - indexCol));
            return distance <= radius;
        }
    }
}
