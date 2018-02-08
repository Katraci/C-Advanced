using System;
using System.Linq;

namespace Problem_7_Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int filter = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.Length <= filter).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
