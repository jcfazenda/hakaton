using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleObjetivoControleRepository : IRepository<ControleObjetivoControle, decimal>
    {
        IQueryable<ControleObjetivoControle> GetByControle(long id);
        bool Create(ControleObjetivoControleInput input);
        bool Remove(long id);

    }
}
