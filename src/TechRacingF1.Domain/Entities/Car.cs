using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("CARS", Schema = "dbo")]
    public class Car
    {
        [Column("card_id")]
        public int CardId { get; set; }
        public required string Model { get; set; }
        public decimal Difficulty { get; set; }
        [Column("consumption_fuel")]
        public int ConsumptionFuel { get; set; }


    }
}
