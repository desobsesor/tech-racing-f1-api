namespace TechRacingF1.Application.Features.Weathers.Queries
{
    public class WeatherDTO
    {
        public int WeatherId { get; set; }
        public required string Condition { get; set; }
        public int Humidity { get; set; }
        public int Temperature { get; set; }
        public decimal RiskFactor { get; set; }
    }
}
