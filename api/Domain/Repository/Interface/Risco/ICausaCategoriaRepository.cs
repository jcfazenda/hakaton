using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface ICausaCategoriaRepository : IRepository<CausaCategoria, decimal>
    {
        IQueryable<CausaCategoria> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(CausaCategoriaInput input);
        bool Update(CausaCategoriaInput input);
        bool Remove(long id);

    }
}
