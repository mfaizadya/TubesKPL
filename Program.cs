using System;
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
        }
    }
}
