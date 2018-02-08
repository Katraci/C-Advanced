using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoft
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison , int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison== "ascending")
            {
                PrintStudents(wantedData.OrderBy(kvp=>kvp.Value.Sum()).Take(studentsToTake).ToDictionary(k=>k.Key,v=>v.Value));
            }
            else
            {
                if (comparison== "descending")
                {
                    PrintStudents(wantedData.OrderByDescending(kvp => kvp.Value.Sum()).Take(studentsToTake).ToDictionary(k => k.Key, v => v.Value));
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                }
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentToSorted)
        {
            foreach (KeyValuePair<string, List<int>> kvp in studentToSorted)
            {
                OutputWriter.PrintStudent(kvp);
            }
        }
        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake,
            Func<KeyValuePair<string,List<int>>,KeyValuePair<string, List<int>>,int> comparisonFunc)
        {

        }
        
    }
}
