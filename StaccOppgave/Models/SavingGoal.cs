using System.Text.Json.Serialization;

namespace StaccOppgave.Models
{
    public class SavingGoal
    {
        [JsonPropertyName("goalId")]
        public int SavingGoalId { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
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
