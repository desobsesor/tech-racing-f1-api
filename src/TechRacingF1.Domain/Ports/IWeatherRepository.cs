using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface IWeatherRepository
    {
        Task<Weather?> GetById(int id);
        Task<IEnumerable<Weather>> GetAll();

    }
}
