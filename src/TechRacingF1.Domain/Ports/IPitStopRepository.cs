using TechRacingF1.Domain.Entities;

namespace TechRacingF1.Domain.Ports
{
    public interface IPitStopRepository
    {
        Task<PitStop?> GetById(int id);
        Task<IEnumerable<PitStop>> GetAll();
        Task<int> Generate(PitStop pitStop);

    }
}
