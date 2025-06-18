using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface IStrategyRepository
    {
        Task<Strategy?> GetById(int id);
        Task<IEnumerable<Strategy>> GetAll();
        Task<int> Create(Strategy strategy);

    }
}
