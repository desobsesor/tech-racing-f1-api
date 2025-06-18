using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface IStrategyDetailRepository
    {
        Task<StrategyDetail?> GetById(int id);
        Task<IEnumerable<StrategyDetail>> GetAll();
        Task<IEnumerable<StrategyDetail>> GetAllByStrategyId(int StrategyId);
        Task<int> Create(StrategyDetail strategyDetail);
    }
}
