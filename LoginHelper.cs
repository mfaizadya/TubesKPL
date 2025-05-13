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

        public static async Task<string> SendLoginRequest(LoginReq loginReq, string loginAs)
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


                return await HandleResponse(response, loginAs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi error: {ex.Message}");
                return null;
            }
        }

        private static async Task<string> HandleResponse(HttpResponseMessage response, string loginAs)
        {
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                if (loginAs == "admin")
                {
                    Console.WriteLine("Login berhasil!");
                } else
                {
                    Console.WriteLine("Login berhasil!");
                }
                return responseBody;
            }
            else
            {
                Console.WriteLine($"Login gagal: {response.StatusCode}");
                string responseBody = await response.Content.ReadAsStringAsync();
                return null;
            }
        }
    }
}
