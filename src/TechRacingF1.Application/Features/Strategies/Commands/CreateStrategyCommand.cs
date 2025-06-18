using MediatR;
using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Application.Features.Strategies.Commands
{
    public class CreateStrategyCommand(Strategy strategy) : IRequest<int>
    {   
        public string StrategyName { get; set; } = strategy.StrategyName;
        public int TotalLaps { get; set; } = strategy.TotalLaps;
        public int PlannedStops { get; set; } = strategy.PlannedStops;
        public decimal EstimatedTime { get; set; } = strategy.EstimatedTime;
        public decimal Risk { get; set; } = strategy.Risk;
        public int WeatherId { get; set; } = strategy.WeatherId;    
        public int TrackId { get; set; } = strategy.TrackId;    

    }
}
