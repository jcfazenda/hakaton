using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoCategoriaRepository : IRepository<RiscoCategoria, decimal>
    {
        IQueryable<RiscoCategoria> GetByRisco(long id);
        bool Create(RiscoCategoriaInput input);
        bool Remove(long id);

    }
}
