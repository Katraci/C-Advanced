using System;
using System.IO;

namespace Problem_1_Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../text.txt");
            using (reader)
            {
                int numberOfLine = 0;
                string line = reader.ReadLine();
                while (line!=null)
                {
                    if (numberOfLine%2==1)
                    {
                        Console.WriteLine(line);
                    }
                    numberOfLine++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
