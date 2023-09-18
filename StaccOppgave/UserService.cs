namespace StaccOppgave
{
    public class UserService
    {
        public int? UserId { get; private set; }
        public string? UserName { get; private set; }
        public void SetUserId(int userId)
        {
            UserId = userId;
        }
        public void SetUserName(string userName)
        {
            UserName = userName;
        }


    }
}
