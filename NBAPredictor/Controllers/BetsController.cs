using Microsoft.AspNetCore.Mvc;
using NBAPredictor.Core.Commands.Bets;

namespace NBAPredictor.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBet(PlaceBetCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
