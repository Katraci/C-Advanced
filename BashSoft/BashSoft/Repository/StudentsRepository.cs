using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCurses;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCurses = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (studentsByCurses.ContainsKey(courseName)&&studentsByCurses[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCurses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarkEntry in studentsByCurses[courseName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }
        public static void GetSudentScoresFromCourse(string cousreName, string username)
        {
            if (IsQueryForStudentPossiblе(cousreName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCurses[cousreName][username]));
            }
        }
        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string patern = @"([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
                Regex rgx = new Regex(patern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if ((!string.IsNullOrEmpty(allInputLines[line]))&&rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        int studentScoreOnTask;
                        bool hasParsetScore=int.TryParse(currentMatch.Groups[3].Value,out  studentScoreOnTask);
                        if (hasParsetScore&&studentScoreOnTask>=0 && studentScoreOnTask<=100)
                        {
                            if (!studentsByCurses.ContainsKey(course))
                            {
                                studentsByCurses.Add(course, new Dictionary<string, List<int>>());
                            }
                            if (!studentsByCurses[course].ContainsKey(student))
                            {
                                studentsByCurses[course].Add(student, new List<int>());
                            }
                            studentsByCurses[course][student].Add(studentScoreOnTask);
                        }
                    }

                }
                
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data Read!");
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake==null)
                {
                    studentsToTake = studentsByCurses[courseName].Count;
                }
                RepositoryFilters.FilterAndTake(studentsByCurses[courseName],givenFilter,studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake=null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCurses[courseName].Count;
                }
                RepositoryFilters.FilterAndTake(studentsByCurses[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}
