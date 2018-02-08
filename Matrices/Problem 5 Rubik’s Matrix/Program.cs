using System;
using System.Linq;

namespace Problem_5_Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            int[,] matrix = new int[row, col];
            int number = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = number;
                    number++;
                }
            }
            int numberOfOperacions = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfOperacions; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                int index = int.Parse(input[0]);
                int rotasion = int.Parse(input[2]);
                switch (input[1])
                {
                    case "up":MoveCol(matrix, index, row-(rotasion%row));break;
                    case "down": MoveCol(matrix, index, rotasion%row); break;
                    case "right": MoveRow(matrix, index, rotasion%col); break;
                    case "left": MoveRow(matrix, index, col-(rotasion%col)); break;
                    default:
                        break;
                }
            }
            number = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    number++;
                    if (matrix[i, j]==number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int k = 0; k < row; k++)
                        {
                            for (int l = 0; l < col; l++)
                            {
                                if (matrix[k,l]==number)
                                {
                                    int token = matrix[i, j];
                                    matrix[i, j] = matrix[k, l];
                                    matrix[k, l] = token;
                                    Console.WriteLine($"Swap ({i}, {j}) with ({k}, {l})");
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MoveRow(int[,] matrix, int index, int rotasion)
        {
            int[] token = new int[matrix.GetLength(1)];
            for (int i = 0; i < token.Length; i++)
            {
                int posicion = (i + rotasion) % token.Length;
                token[posicion] = matrix[index, i];
            }
            for (int i = 0; i < token.Length; i++)
            {
                matrix[index, i] = token[i];
            }
        }

        private static void MoveCol(int[,] matrix, int index, int rotasion)
        {
            int[] token = new int[matrix.GetLength(0)];
            for (int i = 0; i < token.Length; i++)
            {
                int posicion = (i + rotasion) % token.Length;
                token[posicion] = matrix[i, index];
            }
            for (int i = 0; i < token.Length; i++)
            {
                matrix[i, index] = token[i];
            }
        }
    }
}
