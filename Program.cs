using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TubesKPL.SoalEssayLibrary;

namespace TubesKPL
{
    class Program
    {
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
                    case "1": // Registrasi
                        Console.Write("Masukkan username: ");
                        var regUser = Console.ReadLine();
                        Console.Write("Masukkan password: ");
                        var regPass = Console.ReadLine();
                        var registerReq = RegisterHelper.CreateRegisterRequest(regUser, regPass, "pelajar");
                        await RegisterHelper.SendRegisterRequest(registerReq, "pelajar");
                        break;
                    case "2":
                        //
                        break;
                    case "3":
                        Console.WriteLine("melihat level sekarang... (stub)");
                        break;

                    case "4":
                        Console.WriteLine("Mengerjakan soal... (stub)");
                        break;
                    case "5":
                        //
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
                Console.WriteLine("3. Edit Level");
                Console.WriteLine("4. Review Attempt");
                Console.WriteLine("5. Logout");
                Console.Write("Pilih opsi: ");
                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1"://Registrasi
                        Console.Write("Masukkan username: ");
                        var regUser = Console.ReadLine();
                        Console.Write("Masukkan password: ");
                        var regPass = Console.ReadLine();
                        var registerReq = RegisterHelper.CreateRegisterRequest(regUser, regPass, "admin");
                        await RegisterHelper.SendRegisterRequest(registerReq, "admin");
                        break;
                    case "2":
                        //
                        break;
                    case "3":
                        SoalEssayManager soalManager = new SoalEssayManager();

                        Console.Write("Masukkan level: ");
                        string level = Console.ReadLine();

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"== Menu Edit Soal Essay Level {level} ==");

                            // Menampilkan soal berdasarkan level
                            var soalLevel = soalManager.GetSoalsByLevel(int.Parse(level));
                            if (soalLevel.Count == 0)
                            {
                                Console.WriteLine("Tidak ada soal essay di level ini.");
                            }
                            else
                            {
                                foreach (var soal in soalLevel)
                                {
                                    Console.WriteLine($"ID: {soal.Id}, Soal: {soal.Question}");
                                }
                            }

                            Console.WriteLine("1. Tambah Soal Essay");
                            Console.WriteLine("2. Edit Soal Essay");
                            Console.WriteLine("3. Kembali");
                            Console.Write("Pilih opsi: ");
                            var pilihEdit = Console.ReadLine();

                            if (pilihEdit == "1")
                            {
                                // Menambahkan soal baru
                                Console.Write("Masukkan soal essay baru: ");
                                string soalBaru = Console.ReadLine();
                                Console.Write("Masukkan jawaban baru: ");
                                string jawabanBaru = Console.ReadLine();
                                int newId = soalManager.GetSoalsByLevel(int.Parse(level)).Count + 1;
                                soalManager.AddSoal(new SoalEssay(newId, soalBaru, jawabanBaru, int.Parse(level)));
                            }
                            else if (pilihEdit == "2")
                            {
                                // Mengedit soal berdasarkan ID
                                Console.Write("Masukkan ID soal yang ingin diubah: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.Write("Masukkan teks soal essay baru: ");
                                string teksBaru = Console.ReadLine();
                                Console.Write("Masukkan jawaban baru: ");
                                string jawabanBaru = Console.ReadLine();
                                soalManager.EditSoal(id, teksBaru, jawabanBaru);
                            }
                            else if (pilihEdit == "3")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Pilihan tidak valid.");
                            }
                            Console.WriteLine("Tekan Enter untuk melanjutkan...");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        //
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
    }
}
