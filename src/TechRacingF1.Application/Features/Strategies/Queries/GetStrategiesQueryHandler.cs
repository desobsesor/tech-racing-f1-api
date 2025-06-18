using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.Strategies.Queries
{
    public class GetStrategiesQueryHandler(IStrategyRepository strategyRepository, IMapper mapper) : IRequestHandler<GetStrategiesQuery, List<StrategyDTO>>
    {

        public async Task<List<StrategyDTO>> Handle(GetStrategiesQuery request, CancellationToken cancellationToken)
        {
            var strategies = await strategyRepository.GetAll();
            return mapper.Map<List<StrategyDTO>>(strategies);
        }
    }
}
