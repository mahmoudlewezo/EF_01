
using Microsoft.EntityFrameworkCore;
using EF_01.Entities;

namespace EF_01.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=localhost;Database=ReadMoreBooksDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
