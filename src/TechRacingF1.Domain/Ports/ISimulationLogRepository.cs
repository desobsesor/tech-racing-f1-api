using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface ISimulationLogRepository
    {
        Task<SimulationLog?> GetById(int id);
        Task<IEnumerable<SimulationLog>> GetAll();
        Task<int> Generate(SimulationLog simulationLogs);

    }
}
