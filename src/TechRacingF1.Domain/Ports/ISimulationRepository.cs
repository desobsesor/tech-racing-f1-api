using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Entities.Attributes;

namespace TechRacingF1.Domain.Ports
{
    public interface ISimulationRepository
    {
        Task<Simulation?> GetById(int id);
        Task<IEnumerable<Simulation>> GetAll();
        Task<int> Generate(Simulation simulation);
        Task<int> SaveSimulationAsync(
            List<StrategySimulate> strategies,
            int maxLaps,
            int trackId,
            int weatherId,
            int driverId
        );

    }
}
