using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TubesKPL
{
    public static class LoginHelper
    {
        public static LoginReq CreateLoginRequest(string username, string password)
        {
            return new LoginReq
            {
                Username = username,
                Password = password
            };
        }

        public static async Task SendLoginRequest(LoginReq loginReq, string loginAs)
        {
            var httpClient = new HttpClient();

            var json = JsonSerializer.Serialize(loginReq);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            try
            {
                if (loginAs == "admin")
                {
                    response = await httpClient.PostAsync("http://localhost:5209/api/admin/login", content);
                } else
                {
                    response = await httpClient.PostAsync("http://localhost:5209/api/pelajar/login", content);
                }


                    await HandleResponse(response, loginAs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi error: {ex.Message}");
            }
        }

        private static async Task HandleResponse(HttpResponseMessage response, string loginAs)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                if (loginAs == "admin")
                {
                    Console.WriteLine("Login berhasil! Data admin:");
                } else
                {
                    Console.WriteLine("Login berhasil! Data Pelajar:");
                }
                    Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Login gagal: {response.StatusCode}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
        }
    }
}
