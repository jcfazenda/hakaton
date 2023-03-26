using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoResponsavelRepository : IRepository<RiscoResponsavel, decimal>
    {
        IQueryable<RiscoResponsavel> GetByRisco(long id);
        bool Create(RiscoResponsavelInput input);
        bool Remove(long id);

    }
}
