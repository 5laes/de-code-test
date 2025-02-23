using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserQuizAnswer> UserQuizAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserQuizAnswer>()
                .HasKey(k => new { k.PlayerId, k.QuestionId });

            builder.Entity<UserQuizAnswer>()
                .HasOne(s => s.Player)
                .WithMany(l => l.Answers)
                .HasForeignKey(s => s.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<UserQuizAnswer>()
                .HasOne(s => s.Question)
                .WithMany()
                .HasForeignKey(s => s.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}