using System;
using System.Linq;

namespace Problem_11_Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = rowAndCol[0];
            int col = rowAndCol[1];
            string[,] matrix = new string[row, col];
            string input = Console.ReadLine();
            while (input!= "stop")
            {
                int[] carMove=input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int distanse = 0;
                int enter = carMove[0];
                int rowPark = carMove[1];
                int colPark = carMove[2];

                input = Console.ReadLine();
            }
        }
    }
}
