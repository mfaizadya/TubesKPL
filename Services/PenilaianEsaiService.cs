using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesKPL.Models;

namespace TubesKPL.Services
{
    class PenilaianEsaiService
    {
        public static void NilaiEsai()
        {
            var essayAnswers = new List<EssayAnswer>
            {
                new EssayAnswer { Id = 1, StudentName = "Ali", AnswerText = "Pemrograman berorientasi objek menggunakan class dan objek." },
                new EssayAnswer { Id = 2, StudentName = "Budi", AnswerText = "SOLID adalah prinsip penting dalam OOP." },
                new EssayAnswer { Id = 3, StudentName = "Citra", AnswerText = "Inheritance adalah pewarisan sifat dalam OOP." }
            };

            Console.WriteLine("Daftar jawaban esai pelajar:");
            foreach (var e in essayAnswers)
            {
                Console.WriteLine($"ID: {e.Id}, Nama: {e.StudentName}");
            }

            Console.Write("Masukkan ID pelajar yang ingin dinilai: ");
            int id = int.Parse(Console.ReadLine());
            var answer = essayAnswers.FirstOrDefault(e => e.Id == id);

            if (answer == null)
            {
                Console.WriteLine("ID tidak ditemukan.");
                return;
            }

            Console.WriteLine($"\nJawaban dari {answer.StudentName}:");
            Console.WriteLine(answer.AnswerText);

            Console.Write("Masukkan skor maksimal: ");
            int maxScore = int.Parse(Console.ReadLine());

            Console.Write($"Masukkan skor untuk {answer.StudentName}: ");
            int score = int.Parse(Console.ReadLine());

            if (score < 0 || score > maxScore)
            {
                Console.WriteLine("Skor tidak valid.");
                return;
            }

            Console.WriteLine($"\nSkor akhir untuk {answer.StudentName}: {score} dari {maxScore}");
        }
    }
}

