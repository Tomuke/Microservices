using Microservices.Platform.Api.Application.Contracts;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Application.Abstractions
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platform);
    }
}
