using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySkincare.Models
{
    public class QuizQuestion
    {
        [Key]
        public int QID { get; set; }

        public string Question { get; set; }
        //every question is going to have a one to many relationship with its answers, the list represents that relationship
        public IList<QuizAnswer> Answers {get; set;}
    
    }

    public class QuizAnswer
    {
        [Key]
        public int AID { get; set; }

        public string Answer { get; set; }

        public int Value { get; set; }

        public int QID { get; set; }
        //every quiz answer is going to have a relationship back to the question 
        public QuizQuestion Question { get; set; }
    }

    public class QuizResults
    {
        [Key]
        public int RID { get; set; }

        public int Score { get; set; }

        public string SkinType { get; set; }

        public string Regimen { get; set; }

        public int QID { get; set; }
        
        public int AID { get; set; }
        
        public int UID { get; set; }

    }
}
