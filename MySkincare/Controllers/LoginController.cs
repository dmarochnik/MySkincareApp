using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySkincare.Models;

namespace MySkincare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            User u = null;
            using (var db = new UsersContext())
            {
                var login = db.Logins
                    .Where(l => l.Email == request.Username)
                    .FirstOrDefault();
                if (login == null || BCrypt.Net.BCrypt.Verify(request.Password, login.Password) == false)
                {
                    return NotFound("Incorrect username or password");
                }
                u = db.Users
                    .Where(user => user.UID == login.UID)
                    .FirstOrDefault();
                if (u == null)
                {
                    return NotFound("User not found");
                }
            }
            return Ok(u);
        }
    }
}
