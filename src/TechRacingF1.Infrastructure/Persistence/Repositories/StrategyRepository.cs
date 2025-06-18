using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class StrategyRepository(ApplicationDbContext context) : IStrategyRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Strategy?> GetById(int id)
    {
        return await _context.Strategies
            .Include(a => a.Weather)
            .Include(a => a.Track)
            .FirstOrDefaultAsync(a => a.StrategyId == id);
    }

    public async Task<IEnumerable<Strategy>> GetAll()
    {
        return await _context.Strategies
            .Include(a => a.Weather)
            .Include(a => a.Track)
            .ToListAsync();
    }

    public async Task<int> Create(Strategy strategy)
    {
        _context.Strategies.Add(strategy);
        await _context.SaveChangesAsync();
        return strategy.StrategyId;
    }

}
