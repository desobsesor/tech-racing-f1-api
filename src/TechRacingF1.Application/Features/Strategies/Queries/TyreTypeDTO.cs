namespace TechRacingF1.Application.Features.Strategies.Queries
{
    public class TyreTypeDTO
    {
        public string? Name { get; set; }
        public int MaxLaps { get; set; }
        public double FuelPerLap { get; set; }
        public int Performance { get; set; }  // Higher value = better performance
    }
}
