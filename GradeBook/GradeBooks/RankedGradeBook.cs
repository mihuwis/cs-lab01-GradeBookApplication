using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (base.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (base.Students.Count < 5)
            {
                throw new InvalidOperationException("Not enough student in the list");
            }

            List<Double> listOfGrades = base.Students
                .OrderByDescending(student => student.AverageGrade)
                .Select(student => student.AverageGrade)
                .ToList();

            int gradeGroup = (int) Math.Ceiling(listOfGrades.Count * 0.2);

            if (listOfGrades[gradeGroup - 1] <= averageGrade)
            {
                return 'A';
            } else if (listOfGrades[(gradeGroup * 2) - 1 ] <= averageGrade)
            {
                return 'B';
            } else if (listOfGrades[(gradeGroup * 3) -1 ] <= averageGrade)
            {
                return 'C';
            } else if (listOfGrades[(gradeGroup * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
