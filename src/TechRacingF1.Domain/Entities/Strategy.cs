using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("STRATEGIES", Schema = "dbo")]
    public class Strategy
    {
        [Key]
        [Column("strategy_id")]
        public int StrategyId { get; set; }
        [Column("strategy_name")]
        public required string StrategyName { get; set; }
        [Column("total_laps")]
        public int TotalLaps { get; set; }
        [Column("planned_stops")]
        public int PlannedStops { get; set; }
        [Column("estimated_time")]
        public decimal EstimatedTime { get; set; }
        public decimal Risk { get; set; }
        [Column("weather_id")]
        public int WeatherId { get; set; }
        [NotMapped]
        public Weather? Weather { get; set; }
        [Column("track_id")]
        public int TrackId { get; set; }
        [NotMapped]
        public Track? Track { get; set; }
        public ICollection<Simulation>? Simulations { get; private set; }
        public ICollection<StrategyDetail>? StrategyDetails { get; private set; }
        public ICollection<PitStop>? PitStops { get; private set; }
    }
}
