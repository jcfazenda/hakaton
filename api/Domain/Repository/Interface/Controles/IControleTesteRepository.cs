using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleTesteRepository : IRepository<ControleTeste, decimal>
    {
        IQueryable<ControleTeste> GetByControle(long id);
        IQueryable<ControleTeste> GetByTeste(long id);
        bool Create(ControleTesteInput input);
        bool Remove(long id);

    }
}
