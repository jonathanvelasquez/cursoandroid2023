using cursoandroid2023.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace cursoandroid2023.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(X => X.Name).IsUnique();
        }

    }
}
