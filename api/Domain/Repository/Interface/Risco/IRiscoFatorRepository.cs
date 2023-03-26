using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoFatorRepository : IRepository<RiscoFator, decimal>
    {
        IQueryable<RiscoFator> GetByRisco(long id);
        bool Create(RiscoFatorInput input);
        bool Remove(long id);

    }
}
