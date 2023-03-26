using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleRepository : IRepository<Controle, decimal>
    {
        IQueryable<Controle> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(ControleInput input);
        bool Update(ControleInput input);
        bool Remove(long id);

    }
}
