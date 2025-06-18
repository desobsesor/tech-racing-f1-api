using MediatR;

namespace TechRacingF1.Application.Features.Simulations.Queries
{
    public class GetSimulationByIdQuery(int simulationId) : IRequest<SimulationDTO>
    {
        public int SimulationId { get; } = simulationId;
    }
}