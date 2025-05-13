using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesKPL
{
    class AttemptsService
    {
        public static List<Attempt> Attempts = new List<Attempt>
        {
            new Attempt(1, "pela1", "1", 95, DateTime.Now),
            new Attempt(2, "pela2", "1", 70, DateTime.Now.AddDays(-2))
        };

        public static void AttemptsReview(string loginAs, string username)
        {
            int i;
            Console.WriteLine("\n----------Attempt Review----------");
            Console.WriteLine("ID\tUsername\tLevel\tScore\tGrade\tDate");
            if (loginAs == "admin")
            {
                for (i = 0; i < Attempts.Count; i++)
                {
                    Console.WriteLine($"{Attempts[i].AttemptId}\t{Attempts[i].UserName}\t\t{Attempts[i].Level}\t{Attempts[i].Score}\t{GetGradeByScore(Attempts[i].Score)}\t{Attempts[i].AttemptDate}");
                }
            }
            else
            {
                for (i = 0; i < Attempts.Count; i++)
                {
                    if (Attempts[i].UserName == username)
                    {
                        Console.WriteLine($"{Attempts[i].AttemptId}\t{Attempts[i].UserName}\t\t{Attempts[i].Level}\t{Attempts[i].Score}\t{GetGradeByScore(Attempts[i].Score)}\t{Attempts[i].AttemptDate}");
                    }
                }
            }
        }
        public static string GetGradeByScore(double score)
        {
            string[] grade = { "A", "AB", "B", "BC", "C", "D", "E" };
            double[] rangeLimit = { 80.0, 70.0, 65.0, 60.0, 50.0, 40.0, 0.0 };
            int maxGradeLevel = grade.Length - 1;

            string studentGrade = "E";
            int gradeLevel = 0;
            while ((studentGrade == "E") && (gradeLevel < maxGradeLevel))
            {
                if (score > rangeLimit[gradeLevel])
                    studentGrade = grade[gradeLevel];
                gradeLevel = gradeLevel + 1;
            }

            return studentGrade;

        }
    }
}
