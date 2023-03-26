using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoControleRepository : IRepository<RiscoControle, decimal>
    {
        IQueryable<RiscoControle> GetByRisco(long id);
        bool Create(RiscoControleInput input); 
        bool Remove(long id);

    }
}
