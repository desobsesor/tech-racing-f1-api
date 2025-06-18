using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class StrategyDetailRepository(ApplicationDbContext context) : IStrategyDetailRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<StrategyDetail?> GetById(int id)
    {
        return await _context.StrategyDetail
            .Include(a => a.Tyre)
            .Include(a => a.Driver)
            .FirstOrDefaultAsync(a => a.StrategyDetailId == id);
    }

    public async Task<IEnumerable<StrategyDetail>> GetAll()
    {
        return await _context.StrategyDetail
            .Include(a => a.Tyre)
            .Include(a => a.Driver)
            .ToListAsync();
    }

    public async Task<IEnumerable<StrategyDetail>> GetAllByStrategyId(int StrategyId)
    {
        return await _context.StrategyDetail
            .Include(a => a.Strategy)
            .Include(a => a.Tyre)
            .Include(a => a.Driver)
            .Where(p => p.StrategyId == StrategyId)
            .ToListAsync();
    }

    public async Task<int> Create(StrategyDetail strategyDetail)
    {
        _context.StrategyDetail.Add(strategyDetail);
        await _context.SaveChangesAsync();
        return strategyDetail.StrategyId;
    }

}
