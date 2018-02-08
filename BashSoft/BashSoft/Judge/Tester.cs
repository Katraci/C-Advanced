using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BashSoft
{
    class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");

            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOuputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = GetLinesWithPossibleMismatches(actualOuputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {

                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private static string[] GetLinesWithPossibleMismatches(string[] actualOuputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            int minOutputLines = actualOuputLines.Length;
            if (actualOuputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOuputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }
            string[] mismaches = new string[minOutputLines];
            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOuputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (!expectedLine.Equals(actualLine))
                {
                    output = string.Format($"Mismash at line {index} -- expected: \"{expectedLine}\" , actual: \"{actualLine}\"");
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }
                mismaches[index] = output;
            }
            return mismaches;
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
                return;
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
            }
        }


        public static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}
