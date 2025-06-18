using Microsoft.EntityFrameworkCore;
using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Ports;

namespace TechRacingF1.Infrastructure.Persistence.Repositories;

public class TrackRepository(ApplicationDbContext context) : ITrackRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Track?> GetById(int id)
    {
        return await _context.Tracks.FirstOrDefaultAsync(a => a.TrackId == id);
    }

    public async Task<IEnumerable<Track>> GetAll()
    {
        return await _context.Tracks.ToListAsync();
    }

}
