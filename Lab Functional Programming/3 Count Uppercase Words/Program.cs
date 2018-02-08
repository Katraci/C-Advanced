using System;
using System.Linq;

namespace _3_Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x[0] >= 'A' && x[0] <= 'Z').ToArray();
            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
