using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CleanArch_recomend_sistem.Core;
using CleanArch_recomend_sistem.Core.Entities;

namespace CleanArch_recomend_sistem.Infrastructure.Db
{
    public class ProjectContext : DbContext
    {
        class IdConverter() : ValueConverter<Id, Guid>(x => x.Value, x => new Id(x));

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Id>()
                .HaveConversion<IdConverter>();
            base.ConfigureConventions(configurationBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<UserMovieRating> UserMovieRating { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = typeof(IEntity).Assembly
                                             .GetTypes()
                                             .Where(x => typeof(IEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var entityType in entityTypes)
                modelBuilder.Entity(entityType)
                            .Property(nameof(IEntity.Id))
                            .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<UserMovieRating>()
                .HasOne(umr => umr.User)
                .WithMany(u => u.MovieRatings)
                .HasForeignKey(umr => umr.UserId);

            modelBuilder.Entity<UserMovieRating>()
                .HasOne(umr => umr.Movie)
                .WithMany(m => m.MovieRatings)
                .HasForeignKey(umr => umr.MovieId);

            modelBuilder.Entity<User>().HasData(
            new User { Id = new Id(), Name = "John Doe", Email = "johndoe@example.com", Number = "123456789" },
            new User { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "janesmith@example.com", Number = "987654321" },
            new User { Id = Guid.NewGuid(), Name = "Robert Brown", Email = "robertbrown@example.com", Number = "456789123" },
            new User { Id = Guid.NewGuid(), Name = "Alice Johnson", Email = "alicejohnson@example.com", Number = "789123456" },
            new User { Id = Guid.NewGuid(), Name = "David Clark", Email = "davidclark@example.com", Number = "321654987" },
            new User { Id = Guid.NewGuid(), Name = "Emma Harris", Email = "emma@example.com", Number = "654987321" },
            new User { Id = Guid.NewGuid(), Name = "Michael Adams", Email = "michael@example.com", Number = "135792468" },
            new User { Id = Guid.NewGuid(), Name = "Sophia Baker", Email = "sophia@example.com", Number = "246813579" },
            new User { Id = Guid.NewGuid(), Name = "William Scott", Email = "william@example.com", Number = "159753486" },
            new User { Id = Guid.NewGuid(), Name = "Olivia Wilson", Email = "olivia@example.com", Number = "357951486" }
        );

        // Seed Movies
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = Guid.NewGuid(), Title = "The Matrix", Genre = "Sci-Fi", Rating = 8.7 },
            new Movie { Id = Guid.NewGuid(), Title = "Inception", Genre = "Sci-Fi", Rating = 8.8 },
            new Movie { Id = Guid.NewGuid(), Title = "Interstellar", Genre = "Sci-Fi", Rating = 8.6 },
            new Movie { Id = Guid.NewGuid(), Title = "The Dark Knight", Genre = "Action", Rating = 9.0 },
            new Movie { Id = Guid.NewGuid(), Title = "Fight Club", Genre = "Drama", Rating = 8.8 },
            new Movie { Id = Guid.NewGuid(), Title = "Pulp Fiction", Genre = "Crime", Rating = 8.9 },
            new Movie { Id = Guid.NewGuid(), Title = "Forrest Gump", Genre = "Drama", Rating = 8.8 },
            new Movie { Id = Guid.NewGuid(), Title = "The Shawshank Redemption", Genre = "Drama", Rating = 9.3 },
            new Movie { Id = Guid.NewGuid(), Title = "The Godfather", Genre = "Crime", Rating = 9.2 },
            new Movie { Id = Guid.NewGuid(), Title = "The Godfather: Part II", Genre = "Crime", Rating = 9.0 },
            new Movie { Id = Guid.NewGuid(), Title = "The Lord of the Rings: The Fellowship of the Ring", Genre = "Fantasy", Rating = 8.8 },
            new Movie { Id = Guid.NewGuid(), Title = "The Lord of the Rings: The Two Towers", Genre = "Fantasy", Rating = 8.7 },
            new Movie { Id = Guid.NewGuid(), Title = "The Lord of the Rings: The Return of the King", Genre = "Fantasy", Rating = 9.0 },
            new Movie { Id = Guid.NewGuid(), Title = "Star Wars: A New Hope", Genre = "Sci-Fi", Rating = 8.6 },
            new Movie { Id = Guid.NewGuid(), Title = "Star Wars: The Empire Strikes Back", Genre = "Sci-Fi", Rating = 8.7 },
            new Movie { Id = Guid.NewGuid(), Title = "Star Wars: Return of the Jedi", Genre = "Sci-Fi", Rating = 8.3 },
            new Movie { Id = Guid.NewGuid(), Title = "The Silence of the Lambs", Genre = "Thriller", Rating = 8.6 },
            new Movie { Id = Guid.NewGuid(), Title = "Schindler's List", Genre = "History", Rating = 9.0 },
            new Movie { Id = Guid.NewGuid(), Title = "Gladiator", Genre = "Action", Rating = 8.5 },
            new Movie { Id = Guid.NewGuid(), Title = "Braveheart", Genre = "Action", Rating = 8.3 },
            new Movie { Id = Guid.NewGuid(), Title = "Titanic", Genre = "Romance", Rating = 7.9 },
            new Movie { Id = Guid.NewGuid(), Title = "Avatar", Genre = "Sci-Fi", Rating = 7.8 },
            new Movie { Id = Guid.NewGuid(), Title = "The Avengers", Genre = "Action", Rating = 8.0 },
            new Movie { Id = Guid.NewGuid(), Title = "Avengers: Endgame", Genre = "Action", Rating = 8.4 },
            new Movie { Id = Guid.NewGuid(), Title = "Guardians of the Galaxy", Genre = "Action", Rating = 8.1 },
            new Movie { Id = Guid.NewGuid(), Title = "Spider-Man: Into the Spider-Verse", Genre = "Animation", Rating = 8.4 },
            new Movie { Id = Guid.NewGuid(), Title = "The Lion King", Genre = "Animation", Rating = 8.5 },
            new Movie { Id = Guid.NewGuid(), Title = "Frozen", Genre = "Animation", Rating = 7.4 },
            new Movie { Id = Guid.NewGuid(), Title = "Toy Story", Genre = "Animation", Rating = 8.3 },
            new Movie { Id = Guid.NewGuid(), Title = "Toy Story 3", Genre = "Animation", Rating = 8.3 },
            new Movie { Id = Guid.NewGuid(), Title = "Finding Nemo", Genre = "Animation", Rating = 8.1 }
        );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer("Data Source=DESKTOP-JGMMDA2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public ProjectContext() => Database.Migrate();
    }
}
