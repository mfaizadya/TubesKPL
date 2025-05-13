using TubesKPL;
using static TubesKPL.Menambahkan_soal;

public class Program
{
    static void Main()
    {
        LevelManager levelManager = new LevelManager();
        QuestionManager questionManager = new QuestionManager(levelManager);

        while (true)
        {
            Console.WriteLine("\n=== MENU UTAMA ===");
            Console.WriteLine("1. Tambah Level");
            Console.WriteLine("2. Tambah Soal Essay");
            Console.WriteLine("3. Tampilkan Semua Level");
            Console.WriteLine("4. Tampilkan Semua Soal Essay");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih menu: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    levelManager.AddLevelInteractive();
                    break;
                case "2":
                    questionManager.AddEssayQuestionInteractive();
                    break;
                case "3":
                    levelManager.DisplayLevels();
                    break;
                case "4":
                    questionManager.ShowAllQuestions();
                    break;
                case "0":
                    Console.WriteLine("Terima kasih!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
}
