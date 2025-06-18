using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Strategies.Commands
{
    public class CreateStrategyCommandHandler(IStrategyRepository strategyRepository, IMapper mapper) : IRequestHandler<CreateStrategyCommand, int>
    {
        public async Task<int> Handle(CreateStrategyCommand request, CancellationToken cancellationToken)
        {
            // Validate request
            if (string.IsNullOrWhiteSpace(request.StrategyName))
            {
                throw new ArgumentException("Strategy name is required", nameof(request.StrategyName));
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var strategy = new Strategy
                {
                    StrategyName = request.StrategyName,
                    TotalLaps = request.TotalLaps,
                    PlannedStops = request.PlannedStops,
                    EstimatedTime = request.EstimatedTime,
                    Risk = request.Risk,
                    WeatherId = request.WeatherId,
                    TrackId = request.TrackId,
                };
                await strategyRepository.Create(strategy);
                return strategy.StrategyId;
            }
            catch (AutoMapperMappingException ex)
            {
                // Handle mapping errors specifically
                throw new ApplicationException("Error mapping strategy data", ex);
            }
            catch (Exception ex) when (ex is not ArgumentException && ex is not OperationCanceledException)
            {
                // Handle other exceptions
                throw new ApplicationException("Error creating strategy", ex);
            }
        }
    }
}
