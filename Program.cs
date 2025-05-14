using System;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

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

            Debug.Assert(!string.IsNullOrWhiteSpace(username), "Username tidak boleh kosong");
            Debug.Assert(!string.IsNullOrWhiteSpace(password), "Password tidak boleh kosong");

            var loginReq = LoginHelper.CreateLoginRequest(username,password);

            var loginResp = await LoginHelper.SendLoginRequest(loginReq,loginAs);
            if (loginResp != null)
            {
                LoginResponse loginData = JsonSerializer.Deserialize<LoginResponse>(loginResp);

                Debug.Assert(loginData != null, "Deserialisasi loginResp gagal.");
                Debug.Assert(!string.IsNullOrWhiteSpace(loginData.username), "Username dari loginData tidak valid");
                Debug.Assert(!string.IsNullOrWhiteSpace(loginData.nama), "Nama dari loginData tidak valid");

                Console.WriteLine($"Selamat datang {loginData.nama}!");
                string pilih = "0";
                while (pilih != "99")
                {
                    pilih = Menu();
                    switch (pilih)
                    {
                        case "1":
                            AttemptsService.AttemptsReview(loginAs, loginData.username);
                            break;
                        case "99":
                            break;
                        default:
                            Console.WriteLine("Pilihan tidak valid, mohon input kembali.");
                            break;
                    }
                }
            }
        }

        static string Menu()
        {
            Console.WriteLine("\n---------------MENU---------------");
            Console.WriteLine("1. Attempt Review");
            Console.WriteLine("99. Keluar");
            string pilih = Console.ReadLine();
            return pilih;
        }
    }
}
