using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Application.Features.StrategyDetails.Queries
{
    public class StrategyDetailDTO
    {
        public int StrategyDetailId { get; set; }
        public int StrategyId { get; set; }
        public Strategy? Strategy { get; set; }
        public int TyreId { get; set; }
        public Tyre? Tyre { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public int CurveSegment { get; set; }
        public int OrderSegment { get; set; }
    }
}
