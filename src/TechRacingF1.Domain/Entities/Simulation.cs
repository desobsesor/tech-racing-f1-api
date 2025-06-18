using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("SIMULATIONS", Schema = "dbo")]
    public class Simulation
    {
        [Key]
        [Column("simulation_id")]
        public int SimulationId { get; set; }
        [Column("strategy_id")]
        public int StrategyId { get; set; }
        // [NotMapped]
        public Strategy? Strategy { get; private set; }
        [Column("execution_date")]
        public DateTime ExecutionDate { get; set; }
        [Column("weather_id")]
        public int WeatherId { get; set; }
        // [NotMapped]
        public Weather? Weather { get; private set; }
        [Column("track_id")]
        public int TrackId { get; set; }
        // [NotMapped]
        public Track? Track { get; private set; }
        [Column("total_time")]
        public decimal TotalTime { get; set; }
        [Column("royal_stops")]
        public int RoyalStops { get; set; }
        [Column("average_wear")]
        public decimal AverageWear { get; set; }
        [Column("final_state")]
        public required string FinalState { get; set; }
        public ICollection<SimulationLog>? SimulationLogs { get; private set; }
    }
}
