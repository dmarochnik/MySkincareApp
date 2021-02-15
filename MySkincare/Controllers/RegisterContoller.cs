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
        private readonly SkincareContext _context;

        public RegisterController(ILogger<RegisterController> logger, SkincareContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            User u = null;
            Login l = null;

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
            var userEntity = await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            string pass = BCrypt.Net.BCrypt.HashPassword(request.Password);
            l = new Login()
            {
                UID = userEntity.CurrentValues.GetValue<int>("UID"),
                Email = request.Username,
                Password = pass
            };
            _context.Logins.Add(l);
            _context.SaveChanges();

            return Ok(u);
        }

    }
}

