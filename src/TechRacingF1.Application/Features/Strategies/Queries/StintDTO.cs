namespace TechRacingF1.Application.Features.Strategies.Queries
{
    public class StintDTO
    {
        public TyreTypeDTO? Tyre { get; set; }
        public int Laps { get; set; }
        public double? TotalFuel => Laps * Tyre?.FuelPerLap;
        public int? TotalPerformance => Laps * Tyre?.Performance;
    }
}
