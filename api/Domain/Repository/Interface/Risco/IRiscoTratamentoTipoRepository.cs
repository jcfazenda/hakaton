using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoTratamentoTipoRepository : IRepository<RiscoTratamentoTipo, decimal>
    {
        IQueryable<RiscoTratamentoTipo> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(RiscoTratamentoTipoInput input);
        bool Update(RiscoTratamentoTipoInput input);
        bool Remove(long id);

    }
}
