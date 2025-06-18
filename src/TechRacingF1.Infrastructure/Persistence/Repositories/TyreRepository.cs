using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Entities.Attributes;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class TyreRepository(ApplicationDbContext context) : ITyreRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Tyre?> GetById(int id)
    {
        return await _context.Tyres.FirstOrDefaultAsync(a => a.TyreId == id);
    }

    public async Task<IEnumerable<Tyre>> GetAll()
    {
        return await _context.Tyres.ToListAsync();
    }

    public async Task<List<TyreType>> GetTyreTypesAsync()
    {
        var dbTyres = await _context.Tyres.Where(t => t.TyreId != 4 && t.TyreId != 5).ToListAsync();

        return [.. dbTyres.Select(t => new TyreType
        {
            TyreTypeId = t.TyreId,
            Name = t.TyreType,
            MaxLaps = CalculateMaxLaps(t.BaseDegradation),
            FuelPerLap = CalculateFuelConsumption(t.Quality),
            Performance = (int)(t.Quality * 100) // quality 0.95 → Performance 95
        })];
    }

    // Helper methods for business rules
    private static int CalculateMaxLaps(decimal baseDegradation)
    {
        // Example: The greater the degradation, the fewer laps supported
        return (int)(30 * (1 - baseDegradation)); // 30 is an adjustable base value
    }

    private static double CalculateFuelConsumption(decimal quality)
    {
        // Example: Higher quality tires consume less fuel
        return (double)(5.0m - (quality * 0.5m)); // Rango: ~4.5 a 3.8
    }
}
