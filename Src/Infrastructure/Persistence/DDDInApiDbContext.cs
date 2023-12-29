// <copyright file="DDDInApiDbContext.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Domain.Common.Models;
using Domain.Menu;

using Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class DDDInApiDbContext : DbContext
    {
        private readonly PublisDomainEventsInterceptor _publisDomainEventsInterceptor;
        public DDDInApiDbContext(DbContextOptions options, PublisDomainEventsInterceptor publisDomainEventsInterceptor)
            : base(options)
        {
            _publisDomainEventsInterceptor = publisDomainEventsInterceptor;
        }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(
                typeof(DDDInApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publisDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
