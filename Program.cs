using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TubesKPL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Login sebagai admin/pelajar: ");
            string loginAs = Console.ReadLine();

            while (loginAs != "pelajar" && loginAs != "admin")
            {
                Console.Write("Tipe tidak tersedia (case sensitive)\n");
                Console.Write("Login sebagai admin/pelajar: ");
                loginAs = Console.ReadLine();
            }

            Console.Write("Masukkan username: ");
            string username = Console.ReadLine();

            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            var loginReq = LoginHelper.CreateLoginRequest(username,password);

            await LoginHelper.SendLoginRequest(loginReq,loginAs);

            string pilih = "0";
            while (pilih != "99")
            {
                pilih = Menu();
                switch (pilih)
                {
                    case "1":
                        AttemptsReview(loginAs, username);
                        break;
                    case "99":
                        break;
                }
            } 
        }

        static string Menu()
        {
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("1. Attempt Review");
            Console.WriteLine("99. Keluar");
            string pilih = Console.ReadLine();
            return pilih;
        }

        public static List<Attempt> Attempts = new List<Attempt>
        {
            new Attempt(1, "pela1", "1", 95, DateTime.Now),
            new Attempt(2, "pela2", "1", 70, DateTime.Now.AddDays(-2))
        };

        public static void AttemptsReview(string loginAs, string username)
        {
            int i;
            Console.WriteLine("-----Attempt Review-----");
            Console.WriteLine("ID\tUsername\tLevel\tScore\tGrade\tDate");
            if (loginAs == "admin")
            {
                for (i = 0; i < Attempts.Count; i++){
                    Console.WriteLine($"{Attempts[i].AttemptId}\t{Attempts[i].UserName}\t\t{Attempts[i].Level}\t{Attempts[i].Score}\t{GetGradeByScore(Attempts[i].Score)}\t{Attempts[i].AttemptDate}");
                }
            } else
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
