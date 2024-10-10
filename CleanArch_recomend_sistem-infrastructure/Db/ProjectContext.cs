﻿using Microsoft.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = typeof(IEntity).Assembly
                                             .GetTypes()
                                             .Where(x => typeof(IEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var entityType in entityTypes)
                modelBuilder.Entity(entityType)
                            .Property(nameof(IEntity.Id))
                            .HasDefaultValueSql("NEWSEQUENTIALID()");
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
