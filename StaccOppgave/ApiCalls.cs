using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using StaccOppgave.Models;

namespace StaccOppgave
{
    public class ApiCalls
    {
        private readonly HttpClient _httpClient;

        public ApiCalls(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //User
        public async Task<User?> GetUser(string email, string password)
        {
            try
            {

                var apiUrl = new Uri($"https://localhost:7064/User/GetUsers?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");

                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                var user = JsonSerializer.Deserialize<User>(json);
                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
        }


        //Account

        public async Task<Account?> GetAccountForUser(int userid)
        {
            try
            {
               
                var response = await _httpClient.GetAsync($"https://localhost:7064/Account/GetAccountForUser?userId={userid}");
               
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                var account = JsonSerializer.Deserialize<Account>(json);
                if (account == null)
                {
                   return null;
                }
               
                return account;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex; 
            }
        }
    }
}
