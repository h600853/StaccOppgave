namespace StaccOppgave.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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
