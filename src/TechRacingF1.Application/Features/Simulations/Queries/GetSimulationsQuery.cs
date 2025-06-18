using MediatR;

namespace TechRacingF1.Application.Features.Simulations.Queries
{
    public class GetSimulationsQuery : IRequest<List<SimulationDTO>>
    {

    }
}
