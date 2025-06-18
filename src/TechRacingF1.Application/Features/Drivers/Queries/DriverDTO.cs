namespace TechRacingF1.Application.Features.Drivers.Queries
{
    public class DriverDTO
    {
        public int DriverId { get; set; }
        public required string Team { get; set; }
        public required string Fullname { get; set; }
        public required string Nationality { get; set; }
        public decimal DriverLevel { get; set; }
        public decimal Truculence { get; set; }
        public int Experience { get; set; }

    }
}
