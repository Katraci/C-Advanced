using System;
using System.Collections.Generic;

namespace Problem_12_String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string rotacion = Console.ReadLine();
            int firstIndex = rotacion.IndexOf('(');
            int secondIndex = rotacion.IndexOf(')');
            int lenght = secondIndex - firstIndex;
            int rotacionDegree = (int.Parse(rotacion.Substring(firstIndex+1, lenght - 1))) % 360;
            List<string> inputs = new List<string>();
            int maxLenght = -1;
            string input = Console.ReadLine();
            while(input!="END")
            {
                if (input.Length>maxLenght)
                {
                    maxLenght = input.Length;
                }
                inputs.Add(input);
                input = Console.ReadLine();
            }
            char[,] words = new char[inputs.Count,maxLenght];
            for (int i = 0; i <words.GetLength(0); i++)
            {
                char[] token = inputs[i].ToCharArray();
                for (int j = 0; j <words.GetLength(1); j++)
                {
                    if (j<token.Length)
                    {
                        words[i, j] = token[j];
                    }
                    else
                    {
                        words[i, j] = ' ';
                    }
                }
            }
            switch (rotacionDegree)
            {
                case 0:
                case 360:
                    NormalPrint(words);break;
                case 90: RectangularPrint(words);break;
                case 180:ReversPrint(words);break;
                case 270: ReversRectangularPrint(words); break;
                default:
                    break;
            }
        }

        private static void ReversRectangularPrint(char[,] words)
        {
            for (int i = words.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < words.GetLength(0); j++)
                {
                    Console.Write(words[j, i]);
                }
                Console.WriteLine();
            }
        }

        private static void ReversPrint(char[,] words)
        {
            for (int i = words.GetLength(0)-1; i>=0 ; i--)
            {
                for (int j = words.GetLength(1)-1; j>=0; j--)
                {
                    Console.Write(words[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void RectangularPrint(char[,] words)
        {
            for (int i = 0; i < words.GetLength(1); i++)
            {
                for (int j = words.GetLength(0)-1; j >=0; j--)
                {
                    Console.Write(words[j, i]);
                }
                Console.WriteLine();
            }
        }

        private static void NormalPrint(char[,] words)
        {
            for (int i = 0; i < words.GetLength(0); i++)
            {
                for (int j = 0; j < words.GetLength(1); j++)
                {
                    Console.Write(words[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
