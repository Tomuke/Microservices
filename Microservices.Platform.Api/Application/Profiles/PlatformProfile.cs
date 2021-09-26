using AutoMapper;
using Microservices.Platform.Api.Application.Contracts;

namespace Microservices.Platform.Api.Application.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Domain.Platform, PlatformReadDto>();

            CreateMap<PlatformCreateDto, Domain.Platform>();
        }
    }
}
