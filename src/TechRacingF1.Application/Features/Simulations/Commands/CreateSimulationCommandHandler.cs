using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Simulations.Commands
{
    public class CreateSimulationCommandHandler(ISimulationRepository simulationRepository, IMapper mapper) : IRequestHandler<CreateSimulationCommand, int>
    {
        public async Task<int> Handle(CreateSimulationCommand request, CancellationToken cancellationToken)
        {
            // Validate request
            if (string.IsNullOrWhiteSpace(request.FinalState))
            {
                throw new ArgumentException("FinalState is required", nameof(request.FinalState));
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var simulation = new Simulation
                {
                    StrategyId = request.StrategyId,
                    ExecutionDate = DateTime.UtcNow,
                    WeatherId = request.WeatherId,
                    TrackId = request.TrackId,
                    TotalTime = request.TotalTime,
                    RoyalStops = request.RoyalStops,
                    AverageWear = request.AverageWear,
                    FinalState = request.FinalState
                };
                await simulationRepository.Generate(simulation);
                return simulation.SimulationId;
            }
            catch (AutoMapperMappingException ex)
            {
                // Handle mapping errors specifically
                throw new ApplicationException("Error mapping simulation data", ex);
            }
            catch (Exception ex) when (ex is not ArgumentException && ex is not OperationCanceledException)
            {
                // Handle other exceptions
                throw new ApplicationException("Error creating simulation", ex);
            }
        }
    }
}
