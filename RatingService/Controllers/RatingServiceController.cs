using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.RatingService;
using Application.Queries.RatingService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RatingServiceController> _logger;
        public RatingServiceController(IMediator mediator, ILogger<RatingServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateRating")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateRating([FromBody] CreateRatingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        
        [HttpGet(Name = "GetAllRatings")]
        [ProducesResponseType(typeof(IEnumerable<List<RatingResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<RatingResponse>>> GetAllRatings(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllRatingsQuery(), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpGet("{id}", Name = "GetRatingById")]
        [ProducesResponseType(typeof(RatingResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<RatingResponse>> GetRatingById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Rating GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetRatingByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        
        [HttpPut(Name = "UpdateRating")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateRating([FromBody] UpdateRatingCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        

        
        [HttpDelete("{id}", Name = "DeleteRating")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteRating(int id)
        {
            _logger.LogInformation("Rating DELETE request received for ID {id}", id);
            var cmd = new DeleteRatingCommand() { Id = id };
            await _mediator.Send(cmd);
            return NoContent();
        }
        
    }
}
