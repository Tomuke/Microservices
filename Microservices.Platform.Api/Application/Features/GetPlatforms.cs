using AutoMapper;
using MediatR;
using Microservices.Platform.Api.Application.Contracts;
using Microservices.Platform.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Application.Features
{
    [Route("api")]
    [ApiController]
    public class GetPlatformsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetPlatformsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("platforms")]
        public async Task<IActionResult> Endpoint()
        {
            var result = await _mediator.Send(new GetPlatforms.Request());

            return Ok(result);
        }
    }

    public class GetPlatforms
    {
        public class Request : IRequest<Response>
        { }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPlatformRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IPlatformRepository repository, IMapper mapper)
            {
                this._repository = repository;
                this._mapper = mapper;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var platforms = _repository.GetAll().ToList();

                return new Response()
                {
                    Platforms = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms)
                };
            }
        }

        public class Response
        {
            public IEnumerable<PlatformReadDto> Platforms { get; set; }
        }
    }
}
