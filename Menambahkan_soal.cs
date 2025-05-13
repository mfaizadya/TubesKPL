using System;
using System.Collections.Generic;

namespace TubesKPL
{
    public class Menambahkan_soal
    {
        public class Question<T>
        {
            public string Prompt { get; set; }
            public T Answer { get; set; }

            public virtual void Display()
            {
                Console.WriteLine($"Question: {Prompt}");
            }
        }

        public class EssayQuestion : Question<string>
        {
            public override void Display()
            {
                Console.WriteLine($"Essay Question: {Prompt}");
            }
        }

        public class QuestionManager
        {
            private LevelManager levelManager;

            public QuestionManager(LevelManager manager)
            {
                levelManager = manager;
            }

            public void AddEssayQuestionInteractive()
            {
                var levels = levelManager.GetAllLevels();

                if (levels.Count == 0)
                {
                    Console.WriteLine("Tidak ada level. Tambahkan level terlebih dahulu.");
                    return;
                }

                Console.WriteLine("\nPilih ID Level untuk menambahkan soal:");
                foreach (var level in levels)
                {
                    Console.WriteLine($"ID: {level.Id}, Name: {level.Name}");
                }

                Console.Write("Masukkan ID Level: ");
                if (!int.TryParse(Console.ReadLine(), out int levelId))
                {
                    Console.WriteLine("ID tidak valid.");
                    return;
                }

                var selectedLevel = levelManager.GetLevelById(levelId);
                if (selectedLevel == null)
                {
                    Console.WriteLine("Level tidak ditemukan.");
                    return;
                }

                Console.Write("Masukkan Pertanyaan Essay: ");
                string prompt = Console.ReadLine();

                Console.Write("Masukkan Jawaban Essay: ");
                string answer = Console.ReadLine();

                var question = new EssayQuestion
                {
                    Prompt = prompt,
                    Answer = answer
                };

                selectedLevel.Questions.Add(question);
                Console.WriteLine("Soal berhasil ditambahkan ke level!");
            }

            public void ShowAllQuestions()
            {
                Console.WriteLine("\n=== Daftar Soal Essay ===");

                foreach (var level in levelManager.GetAllLevels())
                {
                    foreach (var q in level.Questions)
                    {
                        Console.WriteLine($"Berada di Level: {level.Name} (ID: {level.Id})");
                        q.Display();
                        Console.WriteLine($"Jawaban: {q.Answer}");
                        Console.WriteLine("----------------------------");
                    }
                }
            }
        }
    }
}
