using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleCategoriaObjetivoRepository : IRepository<ControleCategoriaObjetivo, decimal>
    {
        IQueryable<ControleCategoriaObjetivo> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleCategoriaObjetivoInput input);
        long Update(ControleCategoriaObjetivoInput input);
        bool Remove(long id);

    }
}
