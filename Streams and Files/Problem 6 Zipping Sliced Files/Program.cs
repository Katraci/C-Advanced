using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Problem_6_Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to slice:");
            string file = Console.ReadLine();
            Console.WriteLine("How many Parts:");
            int parts = int.Parse(Console.ReadLine());
            Console.WriteLine("Where do you want the result:");
            string directory = Console.ReadLine();
            string type = file.Substring(file.LastIndexOf('.'));
            SliceAndZip(file, directory, parts);
            List<string> files = new List<string>();
            for (int i = 0; i < parts; i++)
            {
                if (directory == string.Empty)
                {
                    directory = "../";
                }
                string curentPartName = directory + $"Part - {i}.gz";
                files.Add(curentPartName);
            }
            AssembleAndUnzip(files, type ,directory);
        }
        static void SliceAndZip(string file, string directory, int parts)
        {
            using (FileStream reader = new FileStream(file, FileMode.Open))
            {
                string type = file.Substring(file.LastIndexOf('.'));
                long partSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long curentPart = 0;
                    if (directory == string.Empty)
                    {
                        directory = "../";
                    }
                    string curentPartName = directory + $"Part - {i}.gz";

                    using (GZipStream writer = new GZipStream(new FileStream(curentPartName, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            curentPart += 4096;
                            if (curentPart >= partSize)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
        static public void AssembleAndUnzip(List<string> files,string type, string directory)
        {
            if (directory == string.Empty)
            {
                directory = "../";
            }
            string name = directory + $"Assemble{type}";
            using (FileStream writer = new FileStream(name, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                foreach (var file in files)
                {
                    using (GZipStream reader = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
