using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly MydatabaseContext dx = new MydatabaseContext();
        private LocalView<Account> Accounts;

        public AccountController(ILogger<AccountController> logger)
        {
            this.Accounts = dx.Accounts.Local;
            dx.Accounts.Load();

            _logger = logger;
        }
        [HttpGet("GetAccountForUser")]
        public IActionResult GetAccountForUser(int userId)
        {
            Account? account = dx.Accounts.FirstOrDefault(x => x.UserId == userId);
            if (account == null)
            {
                return NotFound(new { message = "Account was not found" });
            }
            return Ok(account);
        }
        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Invalid JSON payload");
            }

            Account newaccount = new Account();
            account.UserId = account.UserId;
            account.AccountNumber = account.AccountNumber;
            account.Balance = account.Balance;
            account.Currency = account.Currency;

            dx.Accounts.Add(account);
            dx.SaveChanges();
            return Ok(new { message = "A new account has been created", accountdetails = account });

        }
        [HttpPut("UpdateBalance")]
        public IActionResult updateAccountBalance([FromBody] Account account)
        {

            if (account == null)
            {
                return BadRequest("Invalid JSON payload");
            }
            Account? accountToUpdate = dx.Accounts.FirstOrDefault(x => x.AccountNumber == account.AccountNumber);
            if (accountToUpdate == null)
            {
                return NotFound(new { message = "Account was not found" });
            }
            accountToUpdate.Balance = account.Balance;
            dx.SaveChanges();
            return Ok(new { message = $"balance has been added to your account.", accountData = account });
        }



    }
}
