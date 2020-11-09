using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
  public interface IStackOverflowDBContext
  {
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public int SaveChanges();
  }
}
