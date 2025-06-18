namespace TechRacingF1.Application.Features.Strategies.Queries
{
    public class StrategyDTO
    {
        public int StrategyId { get; set; }
        public required string StrategyName { get; set; }
        public int TotalLaps { get; set; }
        public int PlannedStops { get; set; }
        public decimal EstimatedTime { get; set; }
        public decimal Risk { get; set; }
        public int WeatherId { get; set; }
        public int TrackId { get; set; }

    }
}
