using api.Domain.Models.Indice;
using api.Domain.Views.Input.Indice;
using System.Linq;

namespace api.Domain.Repository.Interface.Indice
{
    public interface IMatrizRepository : IRepository<Matriz, decimal>
    {
        IQueryable<Matriz> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(MatrizInput input);
        bool Update(MatrizInput input);
        bool Remove(long id);

    }
}
