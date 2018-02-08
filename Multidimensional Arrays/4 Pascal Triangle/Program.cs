using System;

namespace _4_Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] triangle = new long[size][];
            for (int i = 0; i < size; i++)
            {
                triangle[i]=new long[i + 1];
                for (int j = 0; j < size; j++)
                {
                    if (j>i)
                    {
                        break;
                    }
                    if (j==0||j==i)
                    {
                        triangle[i][j] = 1;
                    }
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }
            foreach (var row in triangle)
            {
                foreach (var col in row)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
