using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IImpactoRepository : IRepository<Impacto, decimal>
    {
        IQueryable<Impacto> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(ImpactoInput input);
        bool Update(ImpactoInput input);
        bool Remove(long id);

    }
}
