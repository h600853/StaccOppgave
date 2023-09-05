using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SavingGoal
{
    public int GoalId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual User? User { get; set; }
}
