using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechRacingF1.Application.Features.Weathers.Queries;
using TechRacingF1.WebApi.Json;

namespace TechRacingF1.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/weathers")]
    public class WeathersController(IMediator mediator, ILogger<WeathersController> logger) : ApiControllerBase(mediator)
    {

        /// <summary>
        /// Retrieves all Weathers
        /// </summary>
        /// <returns>List of Weathers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<WeatherDTO>> GetAll()
        {
            try
            {
                logger.LogInformation("Getting list of all weathers");
                var query = new GetWeathersQuery();
                var weathers = await Mediator(query);
                return Ok(weathers);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error getting all weathers");

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
