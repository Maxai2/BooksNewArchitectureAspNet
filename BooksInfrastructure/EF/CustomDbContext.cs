using BooksAppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksInfrastructure.EF
{
    public class CustomDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountToken> AccountTokens { get; set; }

        public CustomDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
