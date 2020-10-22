using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySkincare.Models;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Routing;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MySkincare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            User u = null;
            Login l = null;
            using (var db = new UsersContext())
            {
                u = new User()
                {
                    FName = request.FName,
                    LName = request.LName,
                    PhoneNum = request.PhoneNum,
                    StreetAddress = request.StreetAddress,
                    City = request.City,
                    State = request.State,
                    ZIP = request.ZIP
                };
                var userEntity = await db.Users.AddAsync(u);
                await db.SaveChangesAsync();
                string pass = BCrypt.Net.BCrypt.HashPassword(request.Password);
                l = new Login()
                {
                    UID = userEntity.CurrentValues.GetValue<int>("UID"),
                    Email = request.Username,
                    Password = pass
                };
                db.Logins.Add(l);
                db.SaveChanges();
            }
            return Ok(u);
        }

    }
}

