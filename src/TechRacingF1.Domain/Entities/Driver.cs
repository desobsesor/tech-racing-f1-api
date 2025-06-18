using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("DRIVERS", Schema = "dbo")]
    public class Driver
    {
        [Key]
        [Column("driver_id")]
        public int DriverId { get; set; }
        public required string Fullname { get; set; }
        public required string Team { get; set; }
        public required string Nationality { get; set; }
        [Column("driver_level")]
        public decimal DriverLevel { get; set; }
        public decimal Truculence { get; set; }
        public int Experience { get; set; }
        public ICollection<StrategyDetail>? StrategyDetails { get; private set; }
    }
}
