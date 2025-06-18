using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class DriverRepository(ApplicationDbContext context) : IDriverRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Driver?> GetById(int id)
    {
        return await _context.Drivers
            .FirstOrDefaultAsync(a => a.DriverId == id);
    }

    public async Task<IEnumerable<Driver>> GetAll()
    {
        return await _context.Drivers.ToListAsync();
    }

}
