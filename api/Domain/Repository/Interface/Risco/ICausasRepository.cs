using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface ICausasRepository : IRepository<Causas, decimal>
    {
        IQueryable<Causas> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(CausasInput input);
        bool Update(CausasInput input);
        bool Remove(long id);

    }
}
