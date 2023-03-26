using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoIncidenteRepository : IRepository<RiscoIncidente, decimal>
    {
        IQueryable<RiscoIncidente> GetByRisco(long id);
        IQueryable<RiscoIncidente> GetByIncidente(long id);

        bool Create(RiscoIncidenteInput input);
        bool Remove(long id);

    }
}
