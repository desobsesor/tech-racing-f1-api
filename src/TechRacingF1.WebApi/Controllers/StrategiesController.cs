using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Serilog;
using TechRacingF1.Application.Features.Simulations;
using TechRacingF1.Application.Features.Simulations.Queries;
using TechRacingF1.Application.Features.Strategies.Queries;
using TechRacingF1.WebApi.Json;

namespace TechRacingF1.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/strategy")]
    public class StrategiesController(IMediator mediator, ILogger<StrategiesController> logger, SimulateStrategiesUseCase useCase) : ApiControllerBase(mediator)
    {
        [HttpGet("optimal")]
        [Timeout("00:05:00")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateAndReturnStrategies([FromQuery] SimulationGenerateDTO request)
        {
            logger.LogInformation($"Generating optimal strategies for {request.MaxLaps} laps");
            var (listStrategy, totalStrategy) = await useCase.Execute(request);
            logger.LogInformation($"strategies: {totalStrategy} ");
            return Ok(listStrategy);
        }
        /// <summary>
        /// Retrieves all strategies
        /// </summary>
        /// <returns>List of strategies</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StrategyDTO>> GetAll()
        {
            try
            {
                logger.LogInformation("Getting list of all strategies");
                var query = new GetStrategiesQuery();
                var strategies = await Mediator(query);
                return Ok(strategies);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error getting all strategies");

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
