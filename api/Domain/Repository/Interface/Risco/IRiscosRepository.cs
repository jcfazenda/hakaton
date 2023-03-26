using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscosRepository : IRepository<Riscos, decimal>
    {
        IQueryable<Riscos> GetAll(bool active);
        IQueryable<Riscos> GetByRisco(long id);

        bool UpdateStatus(long id);
        bool UpdateExclusivo(long id);

        long Create(RiscosInput input);
        bool Update(RiscosInput input);
        bool UpdateExcluir(long id);
        bool Remove(long id);

    }
}
