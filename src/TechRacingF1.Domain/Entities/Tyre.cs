using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("TYRES", Schema = "dbo")]
    public class Tyre
    {
        [Key]
        [Column("tyre_id")]
        public int TyreId { get; set; }
        [Column("tyre_type")]
        public required string TyreType { get; set; }
        public decimal Quality { get; set; }
        [Column("speed_kmh")]
        public decimal SpeedKmh { get; set; }
        [Column("base_degradation")]
        public decimal BaseDegradation { get; set; }
        public ICollection<StrategyDetail>? StrategyDetails { get; private set; }
        public ICollection<PitStop>? PitStopsNewTyre { get; private set; }
        public ICollection<PitStop>? PitStopsPreviousTyre { get; private set; }
        public ICollection<SimulationLog>? SimulationLogs { get; private set; }

    }
}
