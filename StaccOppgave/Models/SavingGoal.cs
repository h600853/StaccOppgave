namespace StaccOppgave.Models
{
    public class SavingGoal
    {
        public int SavingGoalId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public SavingGoal(int savingGoalId, int userId, string title, string description, decimal price)
        {
            SavingGoalId = savingGoalId;
            UserId = userId;
            Title = title;
            Description = description;
            Price = price;
        }

    }
}
