using AutoMapper;
using MediatR;
using Microservices.Platform.Api.Application.Contracts;
using Microservices.Platform.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Application.Features
{
    [Route("api")]
    [ApiController]
    public class GetPlatformByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetPlatformByIdController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("platforms/{id}", Name ="GetPlatformById")]
        public async Task<IActionResult> Endpoint(int id)
        {
            var result = await _mediator.Send(new GetPlatformById.Request(id));

            if (result.Platform is null)
                return NotFound();

            return Ok(result);
        }
    }

    public class GetPlatformById
    {
        public class Request : IRequest<Response>
        {
            public Request(int id)
            {
                this.Id = id;
            }

            public int Id { get; }
        }

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
                var platform = _repository.GetById(request.Id);

                return new Response()
                {
                    Platform = _mapper.Map<PlatformReadDto>(platform)
                };
            }
        }

        public class Response
        {
            public PlatformReadDto Platform { get; set; }
        }
    }
}
