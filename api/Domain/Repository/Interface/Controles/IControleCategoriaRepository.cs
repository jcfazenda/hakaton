using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleCategoriaRepository : IRepository<ControleCategoria, decimal>
    {
        IQueryable<ControleCategoria> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleCategoriaInput input);
        long Update(ControleCategoriaInput input);
        bool Remove(long id);

    }
}
