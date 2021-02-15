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

        public QuizController(ILogger<QuizController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            IList<QuizQuestion> q = null;

            using (var db = new QuizContext())
            {
                q = db.QuizQuestions
                    .Include(question => question.Answers)
                    .ToList();
            }
            return Ok(q);
        }



    }
}
