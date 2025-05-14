using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TubesKPL;

public class RegisterHelper
{
    public static RegisterRequest CreateRegisterRequest(string username, string password, string role)
    {
        return new RegisterRequest(username, password, role);
    }

    public static async Task SendRegisterRequest(RegisterRequest request, string role)
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        using (HttpClient client = new HttpClient(handler))
        {
            client.Timeout = TimeSpan.FromSeconds(10);
            string endpoint = $"https://localhost:7035/api/auth/{role}/register";

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, request);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registrasi berhasil!");
                }
                else
                {
                    Console.WriteLine($"Registrasi gagal! Status: {(int)response.StatusCode} - {response.ReasonPhrase}");

                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Pesan dari API: {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan koneksi: {ex.Message}");
                Console.WriteLine($"Detail: {ex.InnerException?.Message}");
            }
        }
    }
}
