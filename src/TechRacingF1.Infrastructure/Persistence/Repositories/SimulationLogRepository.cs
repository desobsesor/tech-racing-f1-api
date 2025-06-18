using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class SimulationLogRepository(ApplicationDbContext context) : ISimulationLogRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<SimulationLog?> GetById(int id)
    {
        return await _context.SimulationLogs
            .Include(a => a.Simulation)
            .Include(a => a.Tyre)
            .Include(a => a.Weather)
            .FirstOrDefaultAsync(a => a.SimulationLogId == id);
    }

    public async Task<IEnumerable<SimulationLog>> GetAll()
    {
        return await _context.SimulationLogs
            .Include(a => a.Simulation)
            .Include(a => a.Tyre)
            .Include(a => a.Weather)
            .ToListAsync();
    }
    public async Task<int> Generate(SimulationLog simulationLogs)
    {
        _context.SimulationLogs.Add(simulationLogs);
        await _context.SaveChangesAsync();
        return simulationLogs.SimulationId;
    }

}
