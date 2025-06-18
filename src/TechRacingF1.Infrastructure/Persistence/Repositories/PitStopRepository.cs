using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class PitStopRepository(ApplicationDbContext context) : IPitStopRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<PitStop?> GetById(int id)
    {
        return await _context.PitStops
            .Include(a => a.Strategy)
            .Include(a => a.PreviousTyre)
            .Include(a => a.NewTyre)
            .FirstOrDefaultAsync(a => a.PitStopId == id);
    }

    public async Task<IEnumerable<PitStop>> GetAll()
    {
        return await _context.PitStops
            .Include(a => a.Strategy)
            .Include(a => a.PreviousTyre)
            .Include(a => a.NewTyre)
            .ToListAsync();
    }
    public async Task<int> Generate(PitStop pitStop)
    {
        _context.PitStops.Add(pitStop);
        await _context.SaveChangesAsync();
        return pitStop.PitStopId;
    }

}
