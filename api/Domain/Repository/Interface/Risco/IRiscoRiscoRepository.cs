using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoRiscoRepository : IRepository<RiscoRisco, decimal>
    {
        IQueryable<RiscoRisco> GetByRisco(long id);
        bool Create(RiscoRiscoInput input);
        bool Remove(long id);

    }
}
