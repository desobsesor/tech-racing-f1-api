using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface IDriverRepository
    {
        Task<Driver?> GetById(int id);
        Task<IEnumerable<Driver>> GetAll();

    }
}
