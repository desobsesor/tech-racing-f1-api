namespace TechRacingF1.Domain.Entities.Attributes
{
    public class Stint
    {
        public TyreType? Tyre { get; set; }
        public int Laps { get; set; }
        public double? TotalFuel => Laps * Tyre?.FuelPerLap;
        public int? TotalPerformance => Laps * Tyre?.Performance;
    }
}
