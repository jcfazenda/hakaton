using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoImpactoRepository : IRepository<RiscoImpacto, decimal>
    {
        IQueryable<RiscoImpacto> GetByRisco(long id);
        bool Create(RiscoImpactoInput input);
        bool SaveRiscoImpactoMatriz(RiscoImpactoInput input);

        bool Remove(long id);

    }
}
