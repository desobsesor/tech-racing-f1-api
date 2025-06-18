using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("SIMULATION_LOGS", Schema = "dbo")]
    public class SimulationLog
    {
        [Key]
        [Column("simulation_log_id")]
        public int SimulationLogId { get; set; }
        [Column("simulation_id")]
        public int SimulationId { get; set; }
        public Simulation? Simulation { get; private set; }
        public int Lap { get; set; }
        [Column("time_lap")]
        public decimal TimeLap { get; set; }
        [Column("tyre_id")]
        public int TyreId { get; set; }
        public Tyre? Tyre { get; private set; }
        [Column("current_wear")]
        public decimal CurrentWear { get; set; }
        [Column("remaining_fuel")]
        public decimal RemainingFuel { get; set; }
        [Column("weather_id")]
        public int WeatherId { get; set; }
        public Weather? Weather { get; private set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
