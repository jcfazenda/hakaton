using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleObjetivoRepository : IRepository<ControleObjetivo, decimal>
    {
        IQueryable<ControleObjetivo> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleObjetivoInput input);
        long Update(ControleObjetivoInput input);
        bool Remove(long id);

    }
}
