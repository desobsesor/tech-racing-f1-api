using AutoMapper;
using MediatR;
using TechRacingF1.Application.Features.Simulations.Queries;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Simulations.Queries
{
    /// <summary>
    /// Handler for processing the GetSimulationByIdQuery and returning the simulation details
    /// </summary>
    public class GetSimulationByIdQueryHandler(ISimulationRepository simulationRepository, IMapper mapper) : IRequestHandler<GetSimulationByIdQuery, SimulationDTO>
    {
        public async Task<SimulationDTO> Handle(GetSimulationByIdQuery request, CancellationToken cancellationToken)
        {
            var simulation = await simulationRepository.GetById(request.SimulationId);
            return mapper.Map<SimulationDTO>(simulation);
        }
    }
}