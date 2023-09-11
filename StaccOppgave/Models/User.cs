using System.Text.Json.Serialization;

namespace StaccOppgave.Models
{
    public class User
    {
        [JsonPropertyName("userId")]
        public int Userid { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("passwordHash")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

        public User(int userid, string username, string password, string email)
        {
            Userid = userid;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
