using System;
using System.Collections.Generic;
using System.IO;
using static TubesKPL.Menambahkan_soal;

namespace TubesKPL
{
    public class Tambah_level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question<string>> Questions { get; set; } = new List<Question<string>>();
    }

    public class LevelManager
    {
        private List<Tambah_level> levels;

        public LevelManager()
        {
            levels = new List<Tambah_level>();
        }

        public void AddLevelInteractive()
        {
            Console.Write("Masukkan ID Level: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID tidak valid.");
                return;
            }

            Console.Write("Masukkan Nama Level: ");
            string name = Console.ReadLine();

            levels.Add(new Tambah_level { Id = id, Name = name });
            Console.WriteLine("Level berhasil ditambahkan!");
        }

        public void DisplayLevels()
        {
            Console.WriteLine("\n=== Daftar Level ===");
            foreach (var level in levels)
            {
                Console.WriteLine($"ID: {level.Id}, Name: {level.Name}, Jumlah Soal: {level.Questions.Count}");
            }
        }

        public List<Tambah_level> GetAllLevels()
        {
            return levels;
        }

        public Tambah_level GetLevelById(int id)
        {
            return levels.Find(l => l.Id == id);
        }
    }
}
