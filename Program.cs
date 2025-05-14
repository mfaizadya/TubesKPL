using TubesKPL.Models;
using TubesKPL.Services;

namespace TubesKPL
{
    class program
    {
        static void Main()
        {
            Console.WriteLine("=== MENU UTAMA ===");
            Console.WriteLine("1. Menambahkan soal pilihan ganda");
            Console.WriteLine("2. Menilai jawaban esai pelajar");
            Console.Write("Pilih menu (1/2): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                PilihanGandaService.TambahSoal();
            }
            else if (choice == "2")
            {
                PenilaianEsaiService.NilaiEsai();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }
    }
}