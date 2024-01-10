using LearnDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnDotNet8.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action", DisplayOrder = 1 },
                new Category { CategoryID = 2, CategoryName = "Scifi", DisplayOrder = 2 },
                new Category { CategoryID = 3, CategoryName = "History", DisplayOrder = 3    });
        }
    }
}
