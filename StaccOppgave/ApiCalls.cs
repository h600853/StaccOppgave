using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;

namespace StaccOppgave
{
    public class ApiCalls
    {
        private readonly HttpClient _httpClient;

        public ApiCalls(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAccountForUser(int userid)
        {
            try
            {
               
                var response = await _httpClient.GetAsync($"https://localhost:7064/Account/GetAccountForUser?userId={userid}");
               
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                //var account = JsonSerializer.Deserialize<Account>(json);
                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex; 
            }
        }
    }
}
