using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Domain
{
    public interface IPlatformRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        IEnumerable<Platform> GetAll();

        Platform GetById(int id);

        void Create(Platform platform);
    }
}
