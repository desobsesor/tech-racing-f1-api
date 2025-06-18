using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Simulations.Queries
{
    public class GetSimulationsQueryHandler(ISimulationRepository simulationRepository, IMapper mapper) : IRequestHandler<GetSimulationsQuery, List<SimulationDTO>>
    {

        public async Task<List<SimulationDTO>> Handle(GetSimulationsQuery request, CancellationToken cancellationToken)
        {
            var simulations = await simulationRepository.GetAll();
            return mapper.Map<List<SimulationDTO>>(simulations);
        }
    }
}
