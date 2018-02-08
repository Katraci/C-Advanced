using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Problem_7_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extencion = fileInfo.Extension;
                if (!filesDictionary.ContainsKey(extencion))
                {
                    filesDictionary[extencion] = new List<FileInfo>();
                }
                filesDictionary[extencion].Add(fileInfo);
            }
            filesDictionary = filesDictionary.OrderByDescending(n => n.Value.Count).ThenBy(n => n.Key).ToDictionary(x => x.Key, y => y.Value);
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string directoryAndName = directory + "/report.txt";

            using (var writer =new StreamWriter(directoryAndName))
            {
                foreach (var kvp in filesDictionary)
                {
                    string extenction = kvp.Key;
                    var fileInfo = kvp.Value.OrderByDescending(n=>n.Length);
                    writer.WriteLine(extenction);
                    foreach (var info in fileInfo)
                    {
                        double size = (double)info.Length / 1024;
                        writer.WriteLine($"--{info.Name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
