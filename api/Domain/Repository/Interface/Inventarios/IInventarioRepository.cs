using api.Domain.Models.Inventarios;
using api.Domain.Views.Input.Inventarios;
using System.Linq;

namespace api.Domain.Repository.Interface.Inventarios
{
    public interface IInventarioRepository : IRepository<Inventario, decimal>
    {
        IQueryable<Inventario> GetAll(bool active);

        bool UpdateStatus(long id);
        bool Anexo(InventarioInput input);
        bool Create(InventarioInput input);
        bool Update(InventarioInput input);
        bool Remove(long id);

    }
}
