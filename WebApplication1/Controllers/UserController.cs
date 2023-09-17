using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly MydatabaseContext dx = new MydatabaseContext();
        private LocalView<User> Users;

        public UserController(ILogger<UserController> logger)
        {
            this.Users = dx.Users.Local;
            dx.Users.Load();


            _logger = logger;
        }

        [HttpGet("GetUsers")]
        public IActionResult getUser(string email, string password)
        {
            User? user = dx.Users.FirstOrDefault(x => x.Email.Equals(email) && x.PasswordHash.Equals(password));
            if (user == null)
            {
                return NotFound(new { message = "User was not found" });
            }
            return Ok(new { message = "A user was found", userdata = user });




        }
        [HttpPost("CreateUser")]

        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid JSON payload");
            }

            User newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };

            dx.Users.Add(newUser);
            dx.SaveChanges();

            return Ok(new { message = "User was created", userdata = newUser });
        }



    }
}
