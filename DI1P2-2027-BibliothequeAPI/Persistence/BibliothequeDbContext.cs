namespace DI1P2_2027_BibliothequeAPI.Persistence
{
    using DI1P2_2027_BibliothequeAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class BibliothequeDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbOptions = configuration.GetSection("Database");

            var dbHost = dbOptions.GetValue<string>("Host");
            var dbPort = dbOptions.GetValue<string>("Port");
            var dbName = dbOptions.GetValue<string>("Name");
            var dbUser = dbOptions.GetValue<string>("User");
            var dbPass = dbOptions.GetValue<string>("Pass");
            var useAd = dbOptions.GetValue<bool>("UseAd");
            var dbConnectionString = $"Host={dbHost};Port={dbPort};Db={dbName};Username={dbUser};Password={dbPass}";
            if(useAd)
            {
                dbConnectionString = $"Server={dbHost};Database={dbName};Integrated Security=true;";
            }

            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration pour la table "Status"
            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status"); // Nom de la table
                entity.HasKey(e => e.id); // Clé primaire
                entity.Property(e => e.name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.maxBooks).IsRequired();
            });

            // Configuration pour la table "User"
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.firstname).HasMaxLength(255).IsRequired();
                entity.Property(e => e.password).HasMaxLength(1024).IsRequired();

                // Clé étrangère vers "Status"
                entity.HasOne(e => e.statusCast)
                    .WithMany()
                    .HasForeignKey(e => e.statusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuration pour la table "Author"
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.firstname).HasMaxLength(255).IsRequired();
                entity.Property(e => e.description).HasColumnType("TEXT").IsRequired();
            });

            // Configuration pour la table "Book"
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");
                entity.HasKey(e => e.isbn);
                entity.Property(e => e.title).HasMaxLength(255).IsRequired();
                entity.Property(e => e.publishdate).HasMaxLength(255).IsRequired();

                // Clé étrangère vers "Author"
                entity.HasOne(e => e.authorCast)
                    .WithMany()
                    .HasForeignKey(e => e.authorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuration pour la table "Borrow"
            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.ToTable("borrow");
                entity.HasKey(e => e.id);
                entity.Property(e => e.date).IsRequired();

                // Clé étrangère vers "User"
                entity.HasOne(e => e.userCast)
                    .WithMany()
                    .HasForeignKey(e => e.userId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Clé étrangère vers "Book"
                entity.HasOne(e => e.bookCast)
                    .WithMany()
                    .HasForeignKey(e => e.bookIsbn)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}