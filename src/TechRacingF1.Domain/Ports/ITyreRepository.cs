using TechRacingF1.Domain.Entities;
using TechRacingF1.Domain.Entities.Attributes;

namespace TechRacingF1.Domain.Ports
{
    public interface ITyreRepository
    {
        Task<Tyre?> GetById(int id);
        Task<IEnumerable<Tyre>> GetAll();
        Task<List<TyreType>> GetTyreTypesAsync();
    }
}
