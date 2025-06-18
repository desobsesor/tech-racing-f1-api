using TechRacingF1.Application.Features.Strategies.Queries;
using TechRacingF1.Application.Features.Tracks.Queries;
using TechRacingF1.Application.Features.Weathers.Queries;

namespace TechRacingF1.Application.Features.Simulations.Queries
{
    public class SimulationDTO
    {
        public int SimulationId { get; set; }
        public int StrategyId { get; set; }
        public StrategyDTO? Strategy { get; set; }
        public DateTime ExecutionDate { get; set; }
        public int WeatherId { get; set; }
        public WeatherDTO? Weather { get; set; }
        public int TrackId { get; set; }
        public TrackDTO? Track { get; set; }
        public decimal TotalTime { get; set; }
        public int RoyalStops { get; set; }
        public decimal AverageWear { get; set; }
        public required string FinalState { get; set; }
    }
}
