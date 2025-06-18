namespace TechRacingF1.Application.Features.Tracks.Queries
{
    public class TrackDTO
    {
        public int TrackId { get; set; }
        public required string TrackName { get; set; }
        public required string Country { get; set; }
        public int TrackLength { get; set; }
        public int Curves { get; set; }
        public required string AsphaltType { get; set; }
        public decimal TyreWear { get; set; }
    }
}
