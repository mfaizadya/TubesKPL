using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesKPL.Models;

namespace TubesKPL.Services
{
    class PilihanGandaService
    {
        public static void TambahSoal()
        {
            var question = new MultipleChoiceQuestion<string>();
            Console.Write("Masukkan soal: ");
            question.QuestionText = Console.ReadLine();

            Console.Write("Masukkan jumlah opsi: ");
            int optionCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < optionCount; i++)
            {
                Console.Write($"Opsi {i + 1}: ");
                string option = Console.ReadLine();
                question.Options.Add(option);
            }

            Console.Write("Masukkan jawaban benar: ");
            question.CorrectAnswer = Console.ReadLine();

            Console.WriteLine("\nSoal berhasil ditambahkan:");
            Console.WriteLine($"Soal: {question.QuestionText}");
            Console.WriteLine("Opsi:");
            foreach (var opt in question.Options)
            {
                Console.WriteLine($"- {opt}");
            }
            Console.WriteLine($"Jawaban benar: {question.CorrectAnswer}");
        }
    }
}
