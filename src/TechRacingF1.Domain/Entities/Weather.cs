using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("WEATHERS", Schema = "dbo")]
    public class Weather
    {
        [Key]
        [Column("weather_id")]
        public int WeatherId { get; set; }
        public required string Condition { get; set; }
        public decimal Humidity { get; set; }
        public int Temperature { get; set; }
        [Column("risk_factor")]
        public decimal RiskFactor { get; set; }
        public ICollection<Simulation>? Simulations { get; private set; }
        public ICollection<Strategy>? Strategies { get; private set; }
        public ICollection<SimulationLog>? SimulationLogs { get; private set; }
    }
}
