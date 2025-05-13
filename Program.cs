<<<<<<< Updated upstream
﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TubesKPL
{
    class Program
    {
        public static List<Attempt> Attempts = new List<Attempt>
        {
            new Attempt(1, "pela1", "1", 95, DateTime.Now),
            new Attempt(2, "pela2", "1", 70, DateTime.Now.AddDays(-2))
        };

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== MENU UTAMA ====");
                Console.WriteLine("1. Pelajar");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih opsi: ");
                string mainChoice = Console.ReadLine();

                if (mainChoice == "1") await MenuPelajar();
                else if (mainChoice == "2") await MenuAdmin();
                else if (mainChoice == "3") break;
                else Console.WriteLine("Pilihan tidak valid! Tekan Enter...");

                Console.ReadLine();
            }
        }

        static async Task MenuPelajar()
        {
            string username = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== MENU PELAJAR ====");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Melihat level sekarang (stub)");
                Console.WriteLine("4. Mengerjakan soal pada level sekarang (stub)");
                Console.WriteLine("5. Review Attempt");
                Console.WriteLine("6. Logout");
                Console.Write("Pilih opsi: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        //
                        break;
                    case "2":
                        Console.Write("Masukkan username: ");
                        username = Console.ReadLine();
                        Console.Write("Masukkan password: ");
                        var pass = Console.ReadLine();
                        var loginReq = LoginHelper.CreateLoginRequest(username, pass);
                        await LoginHelper.SendLoginRequest(loginReq, "pelajar");
                        break;
                    case "3":
                        Console.WriteLine("Level sekarang: Level 1 (stub)");
                        break;
                    case "4":
                        Console.WriteLine("Mengerjakan soal... (stub)");
                        break;
                    case "5":
                        if (!string.IsNullOrEmpty(username))
                            AttemptsReview("pelajar", username);
                        else
                            Console.WriteLine("Harap login terlebih dahulu!");
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
            }
        }

        static async Task MenuAdmin()
        {
            string username = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== MENU ADMIN ====");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Edit Level (stub termasuk edit soal)");
                Console.WriteLine("4. Review Attempt");
                Console.WriteLine("5. Logout");
                Console.Write("Pilih opsi: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        //
                        break;
                    case "2":
                        Console.Write("Masukkan username: ");
                        username = Console.ReadLine();
                        Console.Write("Masukkan password: ");
                        var pass = Console.ReadLine();
                        var loginReq = LoginHelper.CreateLoginRequest(username, pass);
                        await LoginHelper.SendLoginRequest(loginReq, "admin");
                        break;
                    case "3":
                        Console.WriteLine("Edit level & soal... (stub)");
                        break;
                    case "4":
                        AttemptsReview("admin", username);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
                Console.WriteLine("Tekan Enter untuk melanjutkan...");
                Console.ReadLine();
            }
        }

        public static void AttemptsReview(string loginAs, string username)
        {
            Console.WriteLine("-----Attempt Review-----");
            Console.WriteLine("ID\tUsername\tLevel\tScore\tGrade\tDate");
            foreach (var attempt in Attempts)
            {
                if (loginAs == "admin" || attempt.UserName == username)
                {
                    Console.WriteLine($"{attempt.AttemptId}\t{attempt.UserName}\t{attempt.Level}\t{attempt.Score}\t{GetGradeByScore(attempt.Score)}\t{attempt.AttemptDate}");
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
                gradeLevel++;
            }
            return studentGrade;
        }
    }
}
>>>>>>> Stashed changes
