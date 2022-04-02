using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //ile stanowi 20%
            int ile = Students.Count;
            if (ile < 5)
                throw new InvalidOperationException();

            int n = ile / 5;
            int higher = 0;
            foreach (Student student in Students)
            {
                if(student.AverageGrade > averageGrade)
                    higher++;               
            }
            if (higher < n)
                return 'A';
            else if(higher < 2 * n)
                return 'B';
            else if (higher < 3 * n)
                return 'C';
            else if (higher < 4 * n)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
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
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
