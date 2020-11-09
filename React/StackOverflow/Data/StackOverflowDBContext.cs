using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework
{
  public class StackOverflowDBContext : DbContext, IStackOverflowDBContext
  {
    public StackOverflowDBContext(DbContextOptions contextOptions) : base(contextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      var answer = builder.Entity<Answer>();
      answer
      .HasOne(a => a.Question)
      .WithMany(q => q.Answers)
      .HasForeignKey(a => a.QuestionId);
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
  }
}
