using Microservices.Platform.Api.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Infrastructure
{
    public class PlatformDatabaseContext : DbContext, IPlatformDatabaseContext
    {
        public PlatformDatabaseContext(DbContextOptions<PlatformDatabaseContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Domain.Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
