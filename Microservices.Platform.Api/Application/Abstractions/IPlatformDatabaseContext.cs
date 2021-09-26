using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Application.Abstractions
{
    public interface IPlatformDatabaseContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<Domain.Platform> Platforms { get; set; }
    }
}
