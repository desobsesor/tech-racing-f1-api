using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechRacingF1.Application.Features.Drivers.Queries;
using TechRacingF1.WebApi.Json;

namespace TechRacingF1.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/drivers")]
    public class DriversController(IMediator mediator, ILogger<DriversController> logger) : ApiControllerBase(mediator)
    {

        /// <summary>
        /// Retrieves all Drivers
        /// </summary>
        /// <returns>List of Drivers</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DriverDTO>> GetAll()
        {
            try
            {
                logger.LogInformation("Getting list of all drivers");
                var query = new GetDriversQuery();
                var drivers = await Mediator(query);
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error getting all drivers");

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
