using AutoMapper;
using MediatR;
using Microservices.Platform.Api.Application.Abstractions;
using Microservices.Platform.Api.Application.Contracts;
using Microservices.Platform.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Application.Features
{
    [Route("api")]
    [ApiController]
    public class CreatePlatformController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreatePlatformController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("platforms")]
        public async Task<IActionResult> Endpoint(PlatformCreateDto platform)
        {
            var result = await _mediator.Send(new CreatePlatform.Request(platform.Name, platform.Publisher, platform.Cost));

            if (result.Platform is null)
                return NotFound();

            return CreatedAtRoute("GetPlatformById", new { id = result.Platform.Id }, platform);
        }
    }

    public class CreatePlatform
    {
        public class Request : IRequest<Response>
        {
            public Request(string name, string publisher, string cost)
            {
                this.Name = name;
                this.Publisher = publisher;
                this.Cost = cost;
            }

            public string Name { get; }
            public string Publisher { get; }
            public string Cost { get; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPlatformRepository _repository;
            private readonly IMapper _mapper;
            private readonly ICommandDataClient _commandDataClient;

            public Handler(IPlatformRepository repository, IMapper mapper, ICommandDataClient commandDataClient)
            {
                this._repository = repository;
                this._mapper = mapper;
                this._commandDataClient = commandDataClient;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var platform = _mapper.Map<Domain.Platform>(new PlatformCreateDto() 
                { 
                    Name = request.Name, 
                    Publisher = request.Publisher, 
                    Cost = request.Cost 
                });

                _repository.Create(platform);

                await _repository.SaveChangesAsync(cancellationToken);

                var response = new Response()
                {
                    Platform = _mapper.Map<PlatformReadDto>(platform)
                };

                await _commandDataClient.SendPlatformToCommand(response.Platform);

                return response;
            }
        }

        public class Response
        {
            public PlatformReadDto Platform { get; set; }
        }
    }
}
