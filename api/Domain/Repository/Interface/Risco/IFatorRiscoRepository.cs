using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IFatorRiscoRepository : IRepository<FatorRisco, decimal>
    {
        IQueryable<FatorRisco> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(FatorRiscoInput input);
        bool Update(FatorRiscoInput input);
        bool Remove(long id);

    }
}
