using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface ITrackRepository
    {
        Task<Track?> GetById(int id);
        Task<IEnumerable<Track>> GetAll();

    }
}
