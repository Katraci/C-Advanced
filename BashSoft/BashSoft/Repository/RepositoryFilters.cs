using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter== "excellent")
            {
                FilterAndTake(wantedData, x=>x>=5 , studentsToTake);
            }
            else
            {
                if (wantedFilter== "average")
                {
                    FilterAndTake(wantedData, x=>x>=3.5&&x<5 , studentsToTake);
                }
                else
                {
                    if (wantedFilter== "poor")
                    {
                        FilterAndTake(wantedData, x=>x<3.5, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
                    }
                }
            }
        }
        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterPrinted = 0;
            foreach (var userNamePoints in wantedData)
            {
                if (counterPrinted == studentsToTake)
                {
                    break;
                }
                double averageScore = userNamePoints.Value.Average();
                double percentageOfFullfilman = averageScore / 100;
                double mark = percentageOfFullfilman * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userNamePoints);
                    counterPrinted++;
                }
            }
        }

    }
}
