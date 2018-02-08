using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolder = new Queue<string>();
            subFolder.Enqueue(SessionData.currentPath);

            while (subFolder.Count!=0)
            {
                string curentPath = subFolder.Dequeue();
                int identation = curentPath.Split('\\').Length - initialIdentation;
                if (depth - identation < 0)
                {
                    break;
                }
                string identationString = new string('-',identation);
                OutputWriter.WriteMessageOnNewLine(string.Format($"{identationString}{curentPath}"));
                try
                {
                    foreach (var file in Directory.GetDirectories(curentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }
                    foreach (var directoryPath in Directory.GetDirectories(curentPath))
                    {
                        subFolder.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessException);
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }
         
        public static void ChangeCurrentDirectoryRalative(string realativePath)
        {
            if (realativePath=="..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + realativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            SessionData.currentPath = absolutePath;
        }
    }

}
