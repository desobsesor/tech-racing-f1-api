using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechRacingF1.Application.Features.Tracks.Queries;
using TechRacingF1.WebApi.Json;

namespace TechRacingF1.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/tracks")]
    public class TracksController(IMediator mediator, ILogger<TracksController> logger) : ApiControllerBase(mediator)
    {

        /// <summary>
        /// Retrieves all Tracks
        /// </summary>
        /// <returns>List of Tracks</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrackDTO>> GetAll()
        {
            try
            {
                logger.LogInformation("Getting list of all tracks");
                var query = new GetTracksQuery();
                var tracks = await Mediator(query);
                return Ok(tracks);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error getting all tracks");

                var requestId = HttpContext.TraceIdentifier;
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponse
                    {
                        Error = "Server error processing request",
                        RequestId = requestId,
                        Message = ex.Message
                    });
            }
        }

    }
}
