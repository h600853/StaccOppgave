namespace StaccOppgave
{
    public class UserService
    {
        public int UserId { get; private set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

    }
}
