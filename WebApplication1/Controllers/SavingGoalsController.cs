using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SavingGoalsController : ControllerBase
    {
        private readonly ILogger<SavingGoalsController> _logger;
        private readonly MydatabaseContext dx = new MydatabaseContext();
        private LocalView<SavingGoal> savingGoals;
        public SavingGoalsController(ILogger<SavingGoalsController> logger)
        {
            this.savingGoals = dx.SavingGoals.Local;
            dx.SavingGoals.Load();

            _logger = logger;
        }
        [HttpGet("GetSavingGoalsForUser")]
        public IActionResult GetSavingGoalsForUser(int userId)
        {
            List<SavingGoal> savingGoals = dx.SavingGoals.Where(x => x.UserId == userId).ToList();

            if (savingGoals.Count == 0)
            {
                return NotFound(new { message = "No saving goals were found for the user" });
            }

            return Ok(savingGoals);
        }
        [HttpPost("CreateSavingGoal")]
        public IActionResult CreateSavingGoal([FromBody] SavingGoal savingGoal)
        {
            SavingGoal newSG = new SavingGoal();    
            newSG.UserId = savingGoal.UserId;
            newSG.Title = savingGoal.Title;
            newSG.Description = savingGoal.Description;
            newSG.Price = savingGoal.Price;

            savingGoals.Add(newSG);
            dx.SaveChanges();   
            return Ok(new {message =  "A new savingGoal has been created.", savingGoalData = newSG});
        }

        [HttpPut("UpdateSavingGoal")]
        public IActionResult UpdateSavingGoal(int goalId, int userId, string? title, string? description, decimal? price)
        {
            
            SavingGoal? savingGoal = dx.SavingGoals.FirstOrDefault(x => x.GoalId == goalId && x.UserId == userId);

            if (savingGoal == null)
            {
                return NotFound(new { message = "SavingGoal was not found" });
            }

            if (title != null)
            {
                savingGoal.Title = title;
            }

            if (description != null)
            {
                savingGoal.Description = description;
            }

            if (price != null)
            {
                savingGoal.Price = price.Value;
            }

            dx.SaveChanges();

            return Ok(new { message = "SavingGoal was updated", savingGoalData = savingGoal });
        }
        [HttpDelete("DeleteGoal")]
        public IActionResult DeleteGoal(int goalId)
        {
            SavingGoal? savingGoal = dx.SavingGoals.FirstOrDefault(x => x.GoalId == goalId);
            if (savingGoal == null)
            {
                return NotFound(new { message = "SavingGoal was not found" });
            }
            savingGoals.Remove(savingGoal);
            dx.SaveChanges();
            return Ok(new { message = "SavingGoal was deleted", savingGoalData = savingGoal });
        }

    }
}
