namespace DI1P2_2027_BibliothequeAPI.Persistence
{
    using DI1P2_2027_BibliothequeAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class BibliothequeDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
    {
        public DbSet<Status> Status { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Author> Author { get; set; } = null;
        public DbSet<Book> Books { get; set; } = null;
        public DbSet<Borrow> Borrows { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbOptions = configuration.GetSection("Database");

            var dbHost = dbOptions.GetValue<string>("Host");
            var dbPort = dbOptions.GetValue<string>("Port");
            var dbName = dbOptions.GetValue<string>("Name");
            var dbUser = dbOptions.GetValue<string>("User");
            var dbPass = dbOptions.GetValue<string>("Pass");

            var dbConnectionString = $"Host={dbHost};Port={dbPort};Db={dbName};Username={dbUser};Password={dbPass}";

            optionsBuilder.UseSqlServer(dbConnectionString);
        }
    }
}
