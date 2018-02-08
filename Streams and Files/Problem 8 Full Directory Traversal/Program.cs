using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_8_Full_Directory_Traversal
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            List<string> allDirectories=GetDirectories(path);
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            foreach (var dir in allDirectories)
            {
                Dictionary<string, List<FileInfo>> token= GetInfoToDictionary(dir);
                foreach (var kvp in token)
                {
                    if (!filesDictionary.ContainsKey(kvp.Key))
                    {
                        filesDictionary[kvp.Key] = new List<FileInfo>();
                    }
                    foreach (var info in kvp.Value)
                    {
                        filesDictionary[kvp.Key].Add(info);
                    }
                }
            }
            filesDictionary = filesDictionary.OrderByDescending(n => n.Value.Count).ThenBy(n => n.Key).ToDictionary(x => x.Key, y => y.Value);
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string directoryAndName = directory + "/report.txt";

            using (var writer = new StreamWriter(directoryAndName))
            {
                foreach (var kvp in filesDictionary)
                {
                    string extenction = kvp.Key;
                    var fileInfo = kvp.Value.OrderByDescending(n => n.Length);
                    writer.WriteLine(extenction);
                    foreach (var info in fileInfo)
                    {
                        double size = (double)info.Length / 1024;
                        writer.WriteLine($"--{info.Name} - {size:f3}kb");
                    }
                }
            }
        }

        private static Dictionary<string, List<FileInfo>> GetInfoToDictionary( string dir)
        {
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(dir);
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
            return filesDictionary;
        }

        private static List<string> GetDirectories(string path)
        {
            var allDirectories = new List<string>();
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                allDirectories.AddRange(GetDirectories(directory));
            }
            allDirectories.Add(path);
            return allDirectories;
        } 

    }
}
