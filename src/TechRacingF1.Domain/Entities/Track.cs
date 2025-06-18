using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("TRACKS", Schema = "dbo")]
    public class Track
    {
        [Key]
        [Column("track_id")]
        public int TrackId { get; set; }
        [Column("track_name")]
        public required string TrackName { get; set; }
        public required string Country { get; set; }
        [Column("track_length")]
        public int TrackLength { get; set; }
        public int Curves { get; set; }
        [Column("asphalt_type")]
        public required string AsphaltType { get; set; }
        [Column("tyre_wear")]
        public int TyreWear { get; set; }

        public ICollection<Simulation>? Simulations { get; private set; }
        public ICollection<Strategy>? Strategies { get; private set; }
    }
}
