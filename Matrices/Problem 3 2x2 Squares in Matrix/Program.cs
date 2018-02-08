using System;
using System.Linq;

namespace Problem_3_2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            string[,] matrix = new string[row, col];
            int numberOfSquares = 0;
            for (int i = 0; i < row; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    if (matrix[i, j]==matrix[i, j + 1]&&matrix[i + 1, j]==matrix[i + 1, j + 1]&&matrix[i, j + 1]==matrix[i + 1, j])
                    {
                        numberOfSquares++;
                    }
                }
            }
            Console.WriteLine(numberOfSquares);
        }
    }
}
