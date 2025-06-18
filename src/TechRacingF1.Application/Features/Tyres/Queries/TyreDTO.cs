namespace TechRacingF1.Application.Features.Tyres.Queries
{
    public class TyreDTO
    {
        public int TyreId { get; set; }
        public required string TyreType { get; set; }
        public required string Quality { get; set; }
        public required string BaseDegradation { get; set; }
        public required string SpeedKmh { get; set; }


    }
}
