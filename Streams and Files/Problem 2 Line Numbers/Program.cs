using System;
using System.IO;

namespace Problem_2_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader stream = new StreamReader("../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../output.txt"))
                {
                    string line = stream.ReadLine();
                    int lineNumber = 0;
                    while (line!=null)
                    {
                        lineNumber++;
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        line = stream.ReadLine();
                    }
                }
            }
        }
    }
}
