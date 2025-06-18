namespace TechRacingF1.Domain.Entities.Attributes
{
    public class TyreType
    {
        public int TyreTypeId { get; set; }
        public string? Name { get; set; }
        public int MaxLaps { get; set; }
        public double FuelPerLap { get; set; }
        public int Performance { get; set; }
    }
}
