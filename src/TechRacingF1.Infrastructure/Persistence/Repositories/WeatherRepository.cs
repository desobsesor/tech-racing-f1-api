using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class WeatherRepository(ApplicationDbContext context) : IWeatherRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Weather?> GetById(int id)
    {
        return await _context.Weathers
            .FirstOrDefaultAsync(a => a.WeatherId == id);
    }

    public async Task<IEnumerable<Weather>> GetAll()
    {
        return await _context.Weathers
            .ToListAsync();
    }

}
