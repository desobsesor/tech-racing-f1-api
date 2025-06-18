using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("PIT_STOPS", Schema = "dbo")]
    public class PitStop
    {
        [Key]
        [Column("pit_stop_id")]
        public int PitStopId { get; set; }
        [Column("strategy_id")]
        public int StrategyId { get; set; }
        public Strategy Strategy { get; set; } = null!;
        public int Lap { get; set; }
        [Column("time_seconds")]
        public decimal TimeSeconds { get; set; }
        [Column("previous_tyre")]
        public int PreviousTyreId { get; set; }
        [NotMapped]
        public required Tyre PreviousTyre { get; set; }
        [Column("new_tyre")]
        public int NewTyreId { get; set; }
        [NotMapped]
        public required Tyre NewTyre { get; set; }
    }
}
