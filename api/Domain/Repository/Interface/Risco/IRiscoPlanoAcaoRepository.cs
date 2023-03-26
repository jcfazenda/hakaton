using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoPlanoAcaoRepository : IRepository<RiscoPlanoAcao, decimal>
    {
        IQueryable<RiscoPlanoAcao> GetByRisco(long id);
        bool Create(RiscoPlanoAcaoInput input);
        bool Remove(long id);

    }
}
