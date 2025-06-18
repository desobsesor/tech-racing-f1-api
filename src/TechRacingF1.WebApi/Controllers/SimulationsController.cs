using TechRacingF1.Application.Features.Simulations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TechRacingF1.Application.Features.Simulations.Commands;
using TechRacingF1.WebApi.Json;

namespace TechRacingF1.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/simulations")]
    public class SimulationsController(IMediator mediator, ILogger<SimulationsController> logger) : ApiControllerBase(mediator)
    {

        /// <summary>
        /// Retrieves all Simulations
        /// </summary>
        /// <returns>List of Simulations</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SimulationDTO>> GetAll()
        {
            try
            {
                logger.LogInformation("Getting list of all simulations");
                var query = new GetSimulationsQuery();
                var simulations = await Mediator(query);
                return Ok(simulations);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error getting all simulations");

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

        /// <summary>
        /// Retrieves an simulation by its ID
        /// </summary>
        /// <param name="id">Simulation ID</param>
        /// <returns>Simulation data</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SimulationDTO>> GetById(int id)
        {
            try
            {
                var query = new GetSimulationByIdQuery(id);
                var simulation = await Mediator(query);

                return Ok(simulation);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error creating simulation");

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

        /// <summary>
        /// Creates a new simulation
        /// </summary>
        /// <returns>List of Simulations</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Create([FromBody] CreateSimulationCommand command)
        {
            try
            {
                var simulationId = await Mediator(command);
                return CreatedAtAction(nameof(GetById), new { id = simulationId }, simulationId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Log.Error(ex, "Error creating simulation");

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
