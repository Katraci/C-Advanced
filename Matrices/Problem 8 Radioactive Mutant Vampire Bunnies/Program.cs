using System;
using System.Linq;

namespace Problem_8_Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            char[,] field = new char[row, col];
            int[] pIndex = new int[2];
            for (int i = 0; i < row; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < col; j++)
                {
                    field[i, j] = input[j];
                    if (input[j] == 'P')
                    {
                        pIndex[0] = i;
                        pIndex[1] = j;
                    }
                }
            }
            char[] moves = Console.ReadLine().ToCharArray();
            bool win = false;
            int conter = 0;
            while(true)
            {
                bool dead = false;
                int oldRow = pIndex[0];
                int oldCol = pIndex[1];
                if (conter<moves.Length)
                {
                    switch (moves[conter])
                    {
                        case 'L': pIndex[1] = pIndex[1] - 1; break;
                        case 'R': pIndex[1] = pIndex[1] + 1; break;
                        case 'U': pIndex[0] = pIndex[0] - 1; break;
                        case 'D': pIndex[0] = pIndex[0] + 1; break;
                        default:
                            break;
                    }
                    conter++;
                }

                if (pIndex[0] < 0 || pIndex[1] < 0 || pIndex[0] >= field.GetLength(0) || pIndex[1] >= field.GetLength(1))
                {
                    win = true;
                    field[oldRow, oldCol] = '.';
                    pIndex[0] = oldRow;
                    pIndex[1] = oldCol;
                }
                else
                {
                    if (field[pIndex[0], pIndex[1]] == 'B')
                    {
                        dead = true;
                    }
                    else
                    {
                        field[pIndex[0], pIndex[1]] = 'P';
                        field[oldRow, oldCol] = '.';
                    }
                }
               
                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        if (field[j, k] == 'B')
                        {
                            if (k != 0)
                            {
                                if (field[j, k - 1] == 'P')
                                {
                                    dead = true;
                                }
                                field[j, k - 1] = 'b';
                            }
                            if (k != field.GetLength(1) - 1)
                            {
                                if (field[j, k + 1] == 'P')
                                {
                                    dead = true;
                                }
                                field[j, k + 1] = 'b';
                            }
                            if (j != 0)
                            {
                                if (field[j - 1, k] == 'P')
                                {
                                    dead = true;
                                }
                                field[j - 1, k] = 'b';
                            }
                            if (j != field.GetLength(0) - 1)
                            {
                                if (field[j + 1, k] == 'P')
                                {
                                    dead = true;
                                }
                                field[j + 1, k] = 'b';
                            }
                        }
                    }
                }
                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        if (field[j, k] == 'b')
                        {
                            field[j, k] = 'B';
                        }
                    }
                }
                if (win)
                {
                    break;
                }
                if (dead)
                {
                    win = false;
                    break;
                }
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            if (win)
            {
                Console.WriteLine($"won: {pIndex[0]} {pIndex[1]}");
            }
            else
            {
                Console.WriteLine($"dead: {pIndex[0]} {pIndex[1]}");
            }
        }
    }
}
