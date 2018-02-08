using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Problem_3_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream=new StreamReader("../text.txt"))
            {
                using (StreamReader filter=new StreamReader("../words.txt"))
                {
                    using (StreamWriter writer=new StreamWriter("../result.txt"))
                    {
                        Dictionary<string, int> result = new Dictionary<string, int>();
                        List<string> filtes = new List<string>();
                        string curentFilter = filter.ReadLine();
                        while (curentFilter != null)
                        {
                            filtes.Add(curentFilter.Trim());
                            curentFilter = filter.ReadLine();
                        }
                        string line = stream.ReadLine();
                        while (line!=null)
                        {
                                string[] words = Regex.Split(line,@"\W+").Where(t=>t!="").Select(n => n.ToLower()).ToArray();
                                for (int i = 0; i < words.Length; i++)
                                {
                                for (int j = 0; j < filtes.Count; j++)
                                {
                                    if (filtes[j] == words[i])
                                    {
                                        if (!result.ContainsKey(words[i]))
                                        {
                                            result[words[i]] = 1;
                                        }
                                        else
                                        {
                                            result[words[i]]++;
                                        }
                                    }
                                }
                                }

                            line = stream.ReadLine();
                        }
                        var sortedResult = result.OrderByDescending(kvp => kvp.Value);
                        foreach (var kvp in sortedResult)
                        {
                            writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                    }
                }
            }
        }
    }
}
