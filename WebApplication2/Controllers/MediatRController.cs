using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class MediatRController : Controller
    {
        private readonly IMediator _mediator;
        public MediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Test")]
        public async Task<string> Test()
        {
            var response = await _mediator.Send(new PingCommand());
            return $"We got a pong at {response.Timestamp}";
        }
    }


    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }

    public class PingCommand : IRequest<PongResponse>
    {
        // nothing here
    }

    public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow))
              .ConfigureAwait(false);
        }
    }
}
