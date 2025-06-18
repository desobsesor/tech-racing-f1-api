namespace TechRacingF1.Domain.Entities.Attributes
{
    public class StrategySimulate
    {
        public List<Stint> Stints { get; set; } = [];
        public int TotalStops => Stints.Count - 1;
        public int TotalLaps => Stints.Sum(s => s.Laps);
        public double AveragePerformance => (double)Stints.Sum(s => s.TotalPerformance) / TotalLaps;
    }
}
