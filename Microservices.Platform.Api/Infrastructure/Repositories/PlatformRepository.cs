using Microservices.Platform.Api.Application.Abstractions;
using Microservices.Platform.Api.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IPlatformDatabaseContext _context;

        public PlatformRepository(IPlatformDatabaseContext context)
        {
            this._context = context;
        }

        public void Create(Domain.Platform platform)
        {
            if (platform is null)
                throw new ArgumentNullException(nameof(platform));

            _context.Platforms.Add(platform);
        }

        public IEnumerable<Domain.Platform> GetAll()
        {
            return _context.Platforms;
        }

        public Domain.Platform GetById(int id)
        {
            return _context.Platforms.Find(id);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
