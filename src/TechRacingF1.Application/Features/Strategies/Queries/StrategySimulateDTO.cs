namespace TechRacingF1.Application.Features.Strategies.Queries
{
    public class StrategySimulateDTO
    {
        public List<StintDTO> Stints { get; set; } = [];
        public int TotalStops => Stints.Count - 1;
        public int TotalLaps => Stints.Sum(s => s.Laps);
        public double AveragePerformance => (double)Stints.Sum(s => s.TotalPerformance) / TotalLaps;
    }
}
