using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySkincare.Models
{
    public class SkincareContext : DbContext
    {
        public SkincareContext(DbContextOptions<SkincareContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizAnswer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QID);
        }
        
        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }

        // Quiz
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
    }
}
