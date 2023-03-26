using api.Domain.Models.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using System.Linq;

namespace api.Domain.Repository.Interface.Apontamentos
{
    public interface IApontamentoRepository : IRepository<Apontamento, decimal>
    {
        IQueryable<Apontamento> GetAll(bool active);
        bool UpdateStatus(long id);

        bool Create(ApontamentoInput input);
        bool Update(ApontamentoInput input);
        bool Remove(long id);

    }
}
