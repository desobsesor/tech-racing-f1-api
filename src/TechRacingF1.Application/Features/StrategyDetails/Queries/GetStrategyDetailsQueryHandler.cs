using AutoMapper;
using MediatR;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Application.Features.StrategyDetails.Queries
{
    public class GetStrategyDetailsQueryHandler(IStrategyDetailRepository strategyDetailsRepository, IMapper mapper) : IRequestHandler<GetStrategyDetailsQuery, List<StrategyDetailDTO>>
    {

        public async Task<List<StrategyDetailDTO>> Handle(GetStrategyDetailsQuery request, CancellationToken cancellationToken)
        {
            var strategies = await strategyDetailsRepository.GetAll();
            return mapper.Map<List<StrategyDetailDTO>>(strategies);
        }
    }
}
