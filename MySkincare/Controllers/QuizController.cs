using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySkincare.Models;
using Microsoft.EntityFrameworkCore;

namespace MySkincare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly SkincareContext _context;

        public QuizController(ILogger<QuizController> logger, SkincareContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            IList<QuizQuestion> q = null;

            q = _context.QuizQuestions
                .Include(question => question.Answers)
                .ToList();

            return Ok(q);
        }



    }
}
