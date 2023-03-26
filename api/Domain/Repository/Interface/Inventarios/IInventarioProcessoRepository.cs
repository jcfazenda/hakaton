using api.Domain.Models.Inventarios;
using api.Domain.Views.Input.Inventarios;
using System.Linq;

namespace api.Domain.Repository.Interface.Inventarios
{
    public interface IInventarioProcessoRepository : IRepository<InventarioProcesso, decimal>
    {
        IQueryable<InventarioProcesso> GetAll(bool active);
        IQueryable<InventarioProcesso> GetByProcesso(long id);
        bool Create(InventarioProcessoInput input);
        bool Anexo(InventarioProcessoInput input);
        bool Remove(long id);

    }
}
