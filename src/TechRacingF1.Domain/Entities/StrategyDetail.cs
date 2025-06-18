using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechRacingF1.Domain.Entities
{
    [Table("STRATEGY_DETAIL", Schema = "dbo")]
    public class StrategyDetail
    {
        [Key]
        [Column("strategy_detail_id")]
        public int StrategyDetailId { get; set; }
        [Column("strategy_id")]
        public int StrategyId { get; set; }
        public Strategy? Strategy { get; set; }
        [Column("tyre_id")]
        public int TyreId { get; set; }
        public Tyre? Tyre { get; set; }
        [Column("driver_id")]
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        [Column("curve_segment")]
        public int CurveSegment { get; set; }
        [Column("order_segment")]
        public int OrderSegment { get; set; }

    }
}
